using System.Windows;
using System.Windows.Controls;
using Character_system.Character;
using System.Collections.Generic;
using System.IO;
using System;

namespace Character_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Character.Character character = null;
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                frame.Source = new Uri("UI/CharacterPage.xaml", UriKind.RelativeOrAbsolute);
            }
            else
            {
                frame.Source = new Uri("UI/CreateCharacterPage.xaml", UriKind.RelativeOrAbsolute);
            }
        }
    }
}
