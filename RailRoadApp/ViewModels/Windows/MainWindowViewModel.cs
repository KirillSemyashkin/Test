using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using RailRoadApp.Core.Services;
using RailRoadApp.Core.Services.Polygons;
using RailRoadApp.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RailRoadApp.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableRecipient
{
    private readonly NotationProvider notationHelper;
    private readonly INavigationService navigationService;
    private ParkViewModel currentParkViewModel = new();

    public MainWindowViewModel() {
        var vmBuilder = App.Current.Services.GetService<IVMBuilder>() ?? throw new ArgumentNullException(nameof(IVMBuilder));
        var provider = App.Current.Services.GetService<IModelProvider>() ?? throw new ArgumentNullException(nameof(IModelProvider));
        notationHelper = App.Current.Services.GetService<NotationProvider>() ?? throw new ArgumentNullException(nameof(NotationProvider));
        navigationService = App.Current.Services.GetService<INavigationService>() ?? throw new ArgumentNullException(nameof(INavigationService));
        AllStations = provider.GetModels()
            .Select(m => vmBuilder.BuildViewModel(m))
            .ToList();
        AllColors = typeof(KnownColor).GetEnumNames()
            .Select(cn => Color.FromName(cn))
            .ToList();
        currentParkViewModel = new();
        NavigationCommand = new RelayCommand<Window>(NavigateTo);
    }

    public List<StationViewModel> AllStations { get; }

    public List<ParkViewModel> AllParks => CurrentStation?.Parks ?? new();

    public List<Color> AllColors { get; set; } = new();

    public ICommand NavigationCommand { get; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AllParks))]
    private StationViewModel currentStation = new();

    public ParkViewModel CurrentParkViewModel {
        get => currentParkViewModel;
        set {
            currentParkViewModel = value;
            OnPropertyChanged();
            OnParkChanged();
        }
    }

    private void OnParkChanged() {
        CurrentStation.SetSelection(CurrentParkViewModel);
        var polygonPoints = CurrentParkViewModel
            .Tracks
            .SelectMany(t => t.Waypoints)
            .Select(w => w.Value).ToList();
        CurrentStation.ParkNotation = notationHelper.ReturnPolygonNotation(polygonPoints);
    }

    private void NavigateTo(Window? window) {
        navigationService.ShowWindow(Enums.EWindow.PathfinderWindow);
        window?.Close();
    }
}
