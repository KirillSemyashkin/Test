﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RailRoadApp {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RailRoadApp.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Парк:.
        /// </summary>
        public static string ChooseParkLabel {
            get {
                return ResourceManager.GetString("ChooseParkLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Выбирите станцию:.
        /// </summary>
        public static string ChooseStationLabel {
            get {
                return ResourceManager.GetString("ChooseStationLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Выбранные участки не связаны между собой!.
        /// </summary>
        public static string GraphSearchException {
            get {
                return ResourceManager.GetString("GraphSearchException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Цвет заливки:.
        /// </summary>
        public static string HullColorLabel {
            get {
                return ResourceManager.GetString("HullColorLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to К заливке парков.
        /// </summary>
        public static string ParkWindowNavigationLabel {
            get {
                return ResourceManager.GetString("ParkWindowNavigationLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to К поиску пути.
        /// </summary>
        public static string PathfinderNavigationLabel {
            get {
                return ResourceManager.GetString("PathfinderNavigationLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Выбранные:.
        /// </summary>
        public static string SelectedTrackPartsLabel {
            get {
                return ResourceManager.GetString("SelectedTrackPartsLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Участки пути на станции.
        /// </summary>
        public static string TrackPartsCommonLabel {
            get {
                return ResourceManager.GetString("TrackPartsCommonLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Доступные:.
        /// </summary>
        public static string TrackPartsLabel {
            get {
                return ResourceManager.GetString("TrackPartsLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Кликните 2 раза для выбора/снятия выбора элемента.
        /// </summary>
        public static string TrackPartsTooltip {
            get {
                return ResourceManager.GetString("TrackPartsTooltip", resourceCulture);
            }
        }
    }
}
