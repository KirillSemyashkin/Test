using RailRoadApp.Enums;
using RailRoadApp.Views;
using System.Windows;

namespace RailRoadApp.Services;

public class NavigationService : INavigationService
{
    public void ShowWindow(EWindow window) {
        Window view;
        switch (window) {
            case EWindow.ParkWindow:
                view = new MainWindow();
                break;
            case EWindow.PathfinderWindow:
                view = new PathfinderView();
                break;
            default:
                view = new MainWindow();
                break;
        }
        view.Show();
    }
}
