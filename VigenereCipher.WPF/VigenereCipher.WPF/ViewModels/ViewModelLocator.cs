using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace VigenereCipher.WPF.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainWindowViewModel MainWindow => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
