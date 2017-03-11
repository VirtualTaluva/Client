using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using Com.Ericmas001.Windows.Xaml.Helpers;
using VirtualTaluva.ClientWpf.ViewModels;

namespace VirtualTaluva.ClientWpf.Xaml.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel mvm = DataContext as MainWindowViewModel;
            if (mvm != null)
            {
                Activated += (s, ea) => mvm.IsWindowActive = true;
                Deactivated += (s, ea) => mvm.IsWindowActive = false;
            }
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            ((TabControl)sender).SelectedIndex = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindowViewModel mvm = DataContext as MainWindowViewModel;
            if (mvm != null)
            {
                if (mvm.Server != null && mvm.Server.IsConnected)
                    mvm.Server.Disconnect();
            }
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
