using VigenereCipher.WPF.Models.Cipher;
using VigenereCipher.WPF.Models.File;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using System;
using System.Threading.Tasks;

namespace VigenereCipher.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private File file = new File();
        private bool mode = true;
        private string key;
        private bool isLoading = false;
        private readonly IDialogService dialogService;
        public RelayCommand CreateCommand { get; private set; }
        public RelayCommand OpenCommand { get; private set; }
        public RelayCommand SaveAsCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand SetEncryptModeCommand { get; private set; }
        public RelayCommand SetDecryptModeCommand { get; private set; }
        public RelayCommand MessageCommand { get; private set; }
        public RelayCommand ActionCommand { get; private set; }


        /// <summary>
        /// Свойство, отвечающее за текст
        /// </summary>
        public string Text
        {
            get => file.Text;
            set
            {
                file.Text = value;
                RaisePropertyChanged(nameof(Text));
            }
        }
        /// <summary>
        /// Свойство, отвечающее за режим работы программы. Если значение Mode = true, то активирован режим шифрования; 
        /// если Mode = false, то активирован режим дешифрования.
        /// </summary>
        public bool Mode
        {
            get => mode;
            private set
            {
                mode = value;
                RaisePropertyChanged(nameof(Mode));
            }
        }

        public string Key
        {
            get => key;
            set
            {
                key = value;
                RaisePropertyChanged(nameof(Key));
            }
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                RaisePropertyChanged(nameof(IsLoading));
            }
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            CreateCommand = new RelayCommand(() =>
            {
                file = new File();
                RaisePropertyChanged(nameof(Text));
            });
            OpenCommand = new RelayCommand(OpenFile);
            SaveAsCommand = new RelayCommand(SaveAsFile);
            SaveCommand = new RelayCommand(SaveFile);
            SetEncryptModeCommand = new RelayCommand(() => Mode = true);
            SetDecryptModeCommand = new RelayCommand(() => Mode = false);
            ActionCommand = new RelayCommand(
                () =>
                {
                    Task.Run(() =>
                    {
                        this.IsLoading = true;
                        Text = Mode ? Cipher.Encrypt(Text, Key) : Cipher.Decrypt(Text, Key);
                    }).ContinueWith((task) => this.IsLoading = false);
                },
                () => !string.IsNullOrWhiteSpace(Key) && !string.IsNullOrWhiteSpace(Text)
                );
        }

        private void OpenFile()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "Открытие документа",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Текстовый документ (*.txt)|*.txt|Документы Word (*.docx)|*.docx"
            };

            bool? success = dialogService.ShowOpenFileDialog(this, settings);
            if (success == true)
            {
                file.Path = settings.FileName;
                try
                {
                    file.Read();
                    RaisePropertyChanged(nameof(Text));
                }
                catch { dialogService.ShowMessageBox(this, "Не удалось открыть файл!", caption: "Ошибка", icon: System.Windows.MessageBoxImage.Error); }
            }
        }

        private void SaveFile()
        {
            if (file.SavePath == null)
            {
                SaveAsFile();
            }
            else
            {
                file.Save();
                SaveResult();
            }
        }

        private void SaveAsFile()
        {
            var settings = new SaveFileDialogSettings
            {
                Title = "Сохранение документа",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Текстовый документ (*.txt)|*.txt|Документ Word (*.docx)|*.docx",
            };

            bool? success = dialogService.ShowSaveFileDialog(this, settings);
            if (success == true)
            {
                file.SavePath = settings.FileName;
                file.Save();
                SaveResult();
            }
        }
        private void SaveResult()
        {
            if (file.IsSaved)
            {
                dialogService.ShowMessageBox(this, "Файл успешно сохранен!", caption: "Успех");
            }
            else
            {
                dialogService.ShowMessageBox(this, "Не удалось сохранить файл!", caption: "Ошибка", icon: System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
