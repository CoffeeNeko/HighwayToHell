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
        /// Gets the Person property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public PersonViewModel Person
        {
            get
            {
                return GetViewModel<PersonViewModel>();
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
                return new SinViewModel();
            }
        }

        /// <summary>
        /// Gets the SinChoice property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        // ReSharper disable once InconsistentNaming
        public SinChoiceViewModel SinChoice
        {
            get
            {
                return new SinChoiceViewModel();
            }
        }

        /// <summary>
        /// Gets the NewSin property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        // ReSharper disable once InconsistentNaming
        public NewSinViewModel NewSin
        {
            get
            {
                return new NewSinViewModel();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            CleanViewModel<PersonViewModel>();
            CleanViewModel<GUIViewModel>();
            CleanViewModel<MainViewModel>();
        }

        private static void CleanViewModel<T>() where T : class
        {
            try
            {
                var viewModel = ServiceLocator.Current.GetInstance<T>() as ViewModelAbstractBase;
                viewModel.Cleanup();
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