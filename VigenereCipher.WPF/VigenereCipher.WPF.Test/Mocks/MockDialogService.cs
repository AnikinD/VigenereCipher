using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.FolderBrowser;
using MvvmDialogs.FrameworkDialogs.MessageBox;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkTest.Mocks
{
    class MockDialogService : IDialogService
    {
        public bool Activate(INotifyPropertyChanged viewModel)
        {
            throw new NotImplementedException();
        }

        public void Show<[NullableAttribute(0)] T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel) where T : System.Windows.Window
        {
            throw new NotImplementedException();
        }

        public void Show(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel)
        {
            throw new NotImplementedException();
        }

        public void ShowCustom<[NullableAttribute(0)] T>(INotifyPropertyChanged ownerViewModel, INotifyPropertyChanged viewModel) where T : IWindow
        {
            throw new NotImplementedException();
        }

        public bool? ShowCustomDialog<[NullableAttribute(0)] T>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) where T : IWindow
        {
            throw new NotImplementedException();
        }

        public bool? ShowDialog<[NullableAttribute(0)] T>(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel) where T : System.Windows.Window
        {
            throw new NotImplementedException();
        }

        public bool? ShowDialog(INotifyPropertyChanged ownerViewModel, IModalDialogViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public bool? ShowFolderBrowserDialog(INotifyPropertyChanged ownerViewModel, FolderBrowserDialogSettings settings)
        {
            throw new NotImplementedException();
        }

        public System.Windows.MessageBoxResult ShowMessageBox(INotifyPropertyChanged ownerViewModel, string messageBoxText, string caption = "", System.Windows.MessageBoxButton button = 0, System.Windows.MessageBoxImage icon = 0, System.Windows.MessageBoxResult defaultResult = 0)
        {
            throw new NotImplementedException();
        }

        public System.Windows.MessageBoxResult ShowMessageBox(INotifyPropertyChanged ownerViewModel, MessageBoxSettings settings)
        {
            throw new NotImplementedException();
        }

        public bool? ShowOpenFileDialog(INotifyPropertyChanged ownerViewModel, OpenFileDialogSettings settings)
        {
            throw new NotImplementedException();
        }

        public bool? ShowSaveFileDialog(INotifyPropertyChanged ownerViewModel, SaveFileDialogSettings settings)
        {
            throw new NotImplementedException();
        }
    }
}
// Заглушка
namespace CourseworkTest
{
    class NullableAttribute : Attribute
    {
        public NullableAttribute(int v)
        {
        }
    }
}