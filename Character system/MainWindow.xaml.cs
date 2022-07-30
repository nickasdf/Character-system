using System.Windows;
using System.Windows.Controls;
using Character_system.Character;
using System.Collections.Generic;
using System.IO;

namespace Character_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Character.Character character;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Tests

            // 1. Test CharacterAttribute, CharacterAttribute

            /*CharacterAttribute agility = new CharacterAttribute("agility", 5);
            CharacterAttribute crit = new CharacterAttribute("crit", "30%");

            CharacterObject sword = new CharacterObject("Iron sword", "An old iron sword", 4.5f, new List<CharacterAttribute>{agility, crit});

            var textBlock = new TextBlock();
            textBlock.FontSize = 30;
            textBlock.Text = sword.ToString();
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(textBlock);*/

            // 2. Test Load in file, Read from file

            /*string pathFile = "agility.attr";
            CharacterAttribute agility = new CharacterAttribute("agility", 5);
            Services.LoaderReader.WriteToBinaryFile(pathFile, agility);
            bool exist = File.Exists(pathFile);
            CharacterAttribute someAttribute = Services.LoaderReader.ReadFromBinaryFile<CharacterAttribute>(pathFile);

            var textBlock = new TextBlock();
            textBlock.FontSize = 30;
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;

            textBlock.Text = "1 created CharacterAttribute object: \n" + agility.ToString() + '\n' + 
                "2 the file " + pathFile + " exists = " + exist.ToString() + '\n' +
                "3 read CharacterAttribute object from file " + pathFile + ":\n" + someAttribute;

            grid.Children.Add(textBlock); */
        }
    }




}
