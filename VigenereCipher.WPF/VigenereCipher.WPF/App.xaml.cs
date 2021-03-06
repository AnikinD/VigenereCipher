﻿using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs;
using System.Windows;

namespace VigenereCipher.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());
        }
    }
}
