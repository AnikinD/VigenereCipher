using AdonisUI;
using System.Windows;
using System.Windows.Media;

namespace VigenereCipher.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool _isDark = true;

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            ResourceLocator.SetColorScheme(Application.Current.Resources, _isDark ? ResourceLocator.LightColorScheme : ResourceLocator.DarkColorScheme);
            _isDark = !_isDark;
            if (_isDark)
            {
                this.TextBox.Background = (Brush)(new BrushConverter().ConvertFrom("#FF3F3F4D"));
            }
            else
            {
                this.TextBox.Background = (Brush)(new BrushConverter().ConvertFrom("#FFEDEDED"));
            }
        }
    }
}
