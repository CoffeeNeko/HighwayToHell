using System;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace HighwayToHell.GUI.ViewModel
{
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
        /// Gets the Sin property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        // ReSharper disable once InconsistentNaming
        public SinViewModel Sin
        {
            get
            {
                return GetViewModel<SinViewModel>();
            }
        }

        /// <summary>
        /// Gets the Sin property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        // ReSharper disable once InconsistentNaming
        public SinChoiceViewModel SinChoice
        {
            get
            {
                return GetViewModel<SinChoiceViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            CleanViewModel<GUIViewModel>();
            CleanViewModel<MainViewModel>();
            CleanViewModel<SinViewModel>();
            CleanViewModel<SinChoiceViewModel>();
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