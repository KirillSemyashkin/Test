using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RailRoadApp.Core.Services;
using RailRoadApp.Core.Services.Graphs;
using RailRoadApp.Core.Services.Polygons;
using RailRoadApp.Services;
using RailRoadApp.Services.Graphs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TPoint = System.Drawing.Point;

namespace RailRoadApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IGraphFactory<TPoint>, GraphFactrory>();
            services.AddSingleton<IVMBuilder,VMBuilder>();
            services.AddTransient<ITrackViewGraphSearcher, TrackViewGraphSearcher>();
            services.AddTransient<IModelProvider, ModelProvider>();
            services.AddTransient<INavigationService, NavigationService>();
            services.AddTransient<NotationProvider>();


            return services.BuildServiceProvider();
        }
    }
}
