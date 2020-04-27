using CourseworkTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VigenereCipher.WPF.ViewModels;

namespace CourseworkTest
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        private MainWindowViewModel viewModel;
        
        [TestMethod]
        public void SetDecryptModeCommandTest()
        {
            viewModel = new MainWindowViewModel(new MockDialogService());
            // По умолчанию значение Mode = true
            Assert.IsTrue(viewModel.Mode);

            viewModel.SetDecryptModeCommand.Execute(new object());
            // Значение должно быть Mode = false
            Assert.IsFalse(viewModel.Mode);
        }

        [TestMethod]
        public void SetEncryptModeCommandTest()
        {
            viewModel = new MainWindowViewModel(new MockDialogService());
            // По умолчанию значение Mode = true
            Assert.IsTrue(viewModel.Mode);

            viewModel.SetEncryptModeCommand.Execute(new object());
            // Значение должно быть Mode = true
            Assert.IsTrue(viewModel.Mode);
        }

        [TestMethod]
        public void ActionCommandTest()
        {
            viewModel = new MainWindowViewModel(new MockDialogService());
            // По умолчанию значение должно быть false
            Assert.IsFalse(viewModel.ActionCommand.CanExecute(new object()));

            // Значение должно быть false
            viewModel.Key = "ключ";
            Assert.IsFalse(viewModel.ActionCommand.CanExecute(new object()));

            // Значение должно быть true
            viewModel.Text = "текст";
            Assert.IsTrue(viewModel.ActionCommand.CanExecute(new object()));

            // Значение должно быть false
            viewModel.Key = null;
            Assert.IsFalse(viewModel.ActionCommand.CanExecute(new object()));
        }
    }
}
