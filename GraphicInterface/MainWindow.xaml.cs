﻿using GraphicInterface.ViewModeles;
using System.Windows;
using System.Windows.Input;

namespace GraphicInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //ToolTip visiblity
            if (TgBtn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_stat.Visibility = Visibility.Collapsed;
                tt_citoyen.Visibility = Visibility.Collapsed;
                tt_etablisment.Visibility = Visibility.Collapsed;
                tt_exit.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_stat.Visibility = Visibility.Visible;
                tt_citoyen.Visibility = Visibility.Visible;
                tt_etablisment.Visibility = Visibility.Visible;
                tt_exit.Visibility = Visibility.Visible;
            }

        }

      

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Vous Voullez Fermer Cette Application?","Confirmation",
                                           MessageBoxButton.YesNo,MessageBoxImage.Question,MessageBoxResult.No,MessageBoxOptions.None);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        /* Changing View */
        private void AccueilBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeVM();

        }

        private void statestiquesBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StatestiquesVM();

        }

        private void CitoyenBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CitoyenVM();

        }

        private void EtablismentBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EtablisementVM();
        }

        
    }
}
