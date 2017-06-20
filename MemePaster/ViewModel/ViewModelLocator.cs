/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MemePaster"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace MemePaster.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<LoadViewModel>();
        }
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();
        public LoadViewModel Load => ServiceLocator.Current.GetInstance<LoadViewModel>();
  
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}