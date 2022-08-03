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
        public MainWindow()
        {
            InitializeComponent();
        }



        private void TestCharacter()
        {
            List<CharacterAttribute> characterAttributes = new List<CharacterAttribute>();
            characterAttributes.Add(new CharacterAttribute("age", 5923));
            characterAttributes.Add(new CharacterAttribute("width", 100));
            characterAttributes.Add(new CharacterAttribute("height", 2));
            characterAttributes.Add(new CharacterAttribute("dick size", 17));

            List<CharacterObject> items = new List<CharacterObject>();

            List<CharacterAttribute> attributes = new List<CharacterAttribute>();
            attributes.Add(new CharacterAttribute("agility", 30));
            attributes.Add(new CharacterAttribute("attack", 0.2f));

            items.Add(new CharacterObject("bread", "taste and cool bread", 5.2f, new List<CharacterAttribute>(attributes)));

            attributes.Clear();
            attributes.Add(new CharacterAttribute("strength", 20));
            attributes.Add(new CharacterAttribute("armor", 0.4f));

            items.Add(new CharacterObject("crown", "A gold crown", 2.4f, new List<CharacterAttribute>(attributes)));
            items.Add(new CharacterObject("Super crown", "A super gold crown", 10, new List<CharacterAttribute>(attributes)));

            Character.Character.character = new Character.Character(30, "NIGGA", items, characterAttributes);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TestCharacter();
            var attributes = new CharacterStatus().allAttributes;
            foreach (var attribute in attributes)
            {
                DockPanel dockPanel = new DockPanel();
                dockPanel.LastChildFill = false;

                TextBlock textBlock = new TextBlock();
                textBlock.Text = attribute.ToString();
                textBlock.FontSize = 20;
                DockPanel.SetDock(textBlock, Dock.Left);
                dockPanel.Children.Add(textBlock);

                Button removeButton = new Button();
                removeButton.Width = 20;
                removeButton.Height = 20;
                removeButton.Click += Click_RemoveButton;
                DockPanel.SetDock(removeButton, Dock.Right);
                dockPanel.Children.Add(removeButton);

                listboxCharacterStatus.Items.Add(dockPanel);

            }
            listboxCharacterObjects.ItemsSource = Character.Character.character.items;
        }
        private void Click_RemoveButton(object sender, RoutedEventArgs e)
        {

        }
        void addObject(List<CharacterAttribute> lst, int number = 3)
        {
            for (int i = 0; i < number; i++)
            {
                lst.Add(new CharacterAttribute() { name = "Speed", value = 10 });
                lst.Add(new CharacterAttribute() { name = "ebat", value = 10 });
                lst.Add(new CharacterAttribute() { name = "NIHUASEBE", value = 10 });
            }
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
