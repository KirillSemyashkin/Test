using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using RailRoadApp.Core.Services;
using RailRoadApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using RailRoadApp.Services.Graphs;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RailRoadApp.Core.Services.Exceptions;
using System.Windows;
using System.Windows.Media.Animation;
using RailRoadApp.Enums;

namespace RailRoadApp.ViewModels.Windows;

public partial class PathfinderViewModel : ObservableRecipient
{
    private readonly ITrackViewGraphSearcher pathfinder;
    private readonly INavigationService navigationService;
    private StationViewModel currentStation = new();

    public PathfinderViewModel() {
        var vmBuilder = App.Current.Services.GetService<IVMBuilder>() ?? throw new ArgumentNullException(nameof(IVMBuilder));
        var provider = App.Current.Services.GetService<IModelProvider>() ?? throw new ArgumentNullException(nameof(IModelProvider));
        pathfinder = App.Current.Services.GetService<ITrackViewGraphSearcher>() ?? throw new ArgumentNullException(nameof(ITrackViewGraphSearcher));
        navigationService = App.Current.Services.GetService<INavigationService>() ?? throw new ArgumentNullException(nameof(INavigationService));

        AllStations = provider.GetModels()
            .Select(m => vmBuilder.BuildViewModel(m))
            .ToList();
        SelectCommand = new RelayCommand<TrackPartViewModel>(Select);
        DeselectCommand = new RelayCommand<TrackPartViewModel>(Deselect);
        NavigationCommand = new RelayCommand<Window>(NavigateTo);
    }

    public List<StationViewModel> AllStations { get; }

    [ObservableProperty]
    private ObservableCollection<TrackPartViewModel> trackParts = new();
    [ObservableProperty]
    private ObservableCollection<TrackPartViewModel> selectedTrackParts = new();

    [ObservableProperty]
    private TrackPartViewModel trackToSelect = new();

    [ObservableProperty]
    private TrackPartViewModel trackToDeselect = new();

    private bool ReadyForSearching => SelectedTrackParts.Count == 2;

    public StationViewModel CurrentStation {
        get => currentStation;
        set {
            currentStation = value;
            TrackParts = new ObservableCollection<TrackPartViewModel>(value.Parts);
            SelectedTrackParts = new ObservableCollection<TrackPartViewModel>();
            OnPropertyChanged();
        }
    }

    public ICommand SelectCommand { get; }
    public ICommand DeselectCommand { get; }
    public ICommand NavigationCommand { get; }

    private void NavigateTo(Window? window) {
        navigationService.ShowWindow(EWindow.ParkWindow);
        window?.Close();
    }

    private void Select(TrackPartViewModel? model) {
        if (model is null || ReadyForSearching) {
            return;
        }
        TrackParts.Remove(model);
        SelectedTrackParts.Add(model);

        if (ReadyForSearching) {
            PerformSearch();
        }
    }

    private void Deselect(TrackPartViewModel? model) {
        if (model is null) {
            return;
        }

        Flush();
        TrackParts.Add(model);
        SelectedTrackParts.Remove(model);
    }

    private void Flush() {
        foreach (var model in TrackParts.Union(SelectedTrackParts)) {
            model.State = Enums.ETrackState.Default;
        }
    }

    private void Highlight(IEnumerable<TrackPartViewModel> path) {
        foreach (var model in TrackParts) {
            model.State = Enums.ETrackState.Default;
        }
        foreach (var model in SelectedTrackParts) {
            model.State = Enums.ETrackState.Selected;
        }
        foreach (var model in path) {
            model.State = Enums.ETrackState.Highlighted;
        }
    }

    private void PerformSearch() {
        if (!ReadyForSearching) {
            return;
        }

        try {
            var shortPathIds = pathfinder.FindShortest(
                SelectedTrackParts.First(),
                SelectedTrackParts.Last(),
                CurrentStation.Graph);
            var result = TrackParts.Where(p => shortPathIds.Contains(p.Id));
            Highlight(result);
        }
        catch (PartsNotConnectedException) {
            MessageBox.Show(Resources.GraphSearchException);
        }
    }
}