using System.Windows;
using System.Windows.Controls;
using Character_system.Character;
using System.Collections.Generic;
using Character_system.UI;
using System.Windows.Input;
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
            List<CharacterObject> items = new List<CharacterObject>();

            List<CharacterAttribute> attributes = new List<CharacterAttribute>();
            attributes.Add(new CharacterAttribute("Agility", 30));
            attributes.Add(new CharacterAttribute("Attack", 0.2f));

            items.Add(new CharacterObject("Bread", "Taste and cool bread", 5.2f, new List<CharacterAttribute>(attributes)));

            attributes.Clear();
            attributes.Add(new CharacterAttribute("Strength", 20));
            attributes.Add(new CharacterAttribute("Armor", 0.4f));

            items.Add(new CharacterObject("Crown", "A gold crown", 2.4f, new List<CharacterAttribute>(attributes)));
            items.Add(new CharacterObject("Super crown", "A super gold crown", 10, new List<CharacterAttribute>(attributes)));

            Character.Character.character = new Character.Character(30, "NIGGA", items);
        }

        private void Refresh()
        {
            var attributes = new CharacterStatus().allAttributes;

            listboxCharacterStatus.Items.Clear();
            foreach(var attribute in attributes)
            {
                DockPanel dockPanel = new DockPanel();
                dockPanel.LastChildFill = false;

                TextBlockAttribute textBlock = new TextBlockAttribute(attribute);
                DockPanel.SetDock(textBlock, Dock.Left);
                dockPanel.Children.Add(textBlock);

                ButtonRemoveAttribute removeButton = new ButtonRemoveAttribute(attribute);
                removeButton.Click += Click_RemoveButton;
                DockPanel.SetDock(removeButton, Dock.Right);
                dockPanel.Children.Add(removeButton);

                listboxCharacterStatus.Items.Add(dockPanel);
            }

            List<int> indexItemsRewrite = new List<int>();
            for (int i = 0; i < listboxCharacterObjects.Items.Count; i++)
            {
                var dockPanel = listboxCharacterObjects.Items[i] as DockPanel;
                if (dockPanel.Children[0] is TextBlockObject && ((TextBlockObject)dockPanel.Children[0]).ShouldRewrite)
                {
                    indexItemsRewrite.Add(i);
                }
                if (dockPanel.Children[0] is TextBoxObject && ((TextBoxObject)dockPanel.Children[0]).ShouldRewrite)
                {
                    indexItemsRewrite.Add(i);
                }
            }

            listboxCharacterObjects.Items.Clear();
            for (int i = 0; i < Character.Character.character.items.Count; i++)
            {
                DockPanel dockPanel = new DockPanel();
                dockPanel.LastChildFill = false;
                
                if (indexItemsRewrite.Contains(i))
                {
                    TextBoxObject textBox = new TextBoxObject(Character.Character.character.items[i]);
                    textBox.KeyDown += TextBox_KeyDown;
                    DockPanel.SetDock(textBox, Dock.Left);
                    dockPanel.Children.Add(textBox);
                }
                else
                {
                    TextBlockObject textBlock = new TextBlockObject(Character.Character.character.items[i]);
                    textBlock.MouseLeftButtonDown += TextBlock_MouseLeftButtonDown;
                    DockPanel.SetDock(textBlock, Dock.Left);
                    dockPanel.Children.Add(textBlock);
                }

                ButtonRemoveObject removeButton = new ButtonRemoveObject(Character.Character.character.items[i]);
                //removeButton.VerticalAlignment = VerticalAlignment.Top;
                removeButton.Click += RemoveButton_Click;
                DockPanel.SetDock(removeButton, Dock.Right);
                dockPanel.Children.Add(removeButton);

                listboxCharacterObjects.Items.Add(dockPanel);
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var textBox = sender as TextBoxObject;
                textBox.ShouldRewrite = false;
                string[] lines = textBox.Text.Split('\n');
                if (!lines[0].StartsWith("name: "))
                    throw new Exception("ніт");
                textBox.Object.name = lines[0].Substring("name: ".Length);
                if (!lines[1].StartsWith("description: "))
                    throw new Exception("xyz");
                textBox.Object.description = lines[1].Substring("description: ".Length);
                if (!lines[2].StartsWith("weight: "))
                    throw new Exception("AAAAAA");
                textBox.Object.weight = float.Parse(lines[2].Substring("weight: ".Length));
                


                Refresh();
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount > 1)
            {
                var buttonRemove = sender as TextBlockObject;
                buttonRemove.ShouldRewrite = true;
                Refresh();
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonRemoveObject buttonRemove = sender as ButtonRemoveObject;
            Handlers.CharacterHandler.RemoveObject(Character.Character.character, buttonRemove.Object);
            Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TestCharacter();
            Refresh();
        }
        private void Click_RemoveButton(object sender, RoutedEventArgs e)
        {
            foreach (var item in Character.Character.character.items)
            {
                Handlers.CharacterHandler.RemoveAttribute(item, ((ButtonRemoveAttribute)sender).Attribute.name);
            }
            Refresh();
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void Image_MouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Image_MouseEnter_Close(object sender, MouseEventArgs e)
        {

        }
    }
}
