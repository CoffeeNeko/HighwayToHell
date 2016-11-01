/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:GUI.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace HighwayToHell.GUI.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return GetViewModel<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the GUI property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        // ReSharper disable once InconsistentNaming
        public GUIViewModel GUI
        {
            get
            {
                return GetViewModel<GUIViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            CleanViewModel<GUIViewModel>();
            CleanViewModel<MainViewModel>();
        }

        private static void CleanViewModel<T>() where T : class
        {
            try
            {
                var viewModel = ServiceLocator.Current.GetInstance<T>() as ViewModelAbstractBase;
                if (viewModel != null)
                {
                    viewModel.Cleanup();
                }
            }
            catch
            {
                // ignored
            }
        }

        private static T GetViewModel<T>() where T : class
        {
            try
            {
                return ServiceLocator.Current.GetInstance<T>();
            }
            catch (Exception)
            {
                SimpleIoc.Default.Register<T>();
                return ServiceLocator.Current.GetInstance<T>();
            }
        }
    }
}