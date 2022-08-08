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

            var att1 = new List<CharacterAttribute>();
            att1.Add(new CharacterAttribute("Strength", 30));
            att1.Add(new CharacterAttribute("Armor", 0.4f));

            items.Add(new CharacterObject("Crown", "A gold crown", 2.4f, new List<CharacterAttribute>(attributes)));
            items.Add(new CharacterObject("Super crown", "A super gold crown", 10, new List<CharacterAttribute>(att1)));

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

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
                stackPanel.VerticalAlignment = VerticalAlignment.Stretch;

                if (indexItemsRewrite.Contains(i))
                {
                    TextBoxObject textBox = new TextBoxObject(Character.Character.character.items[i]);
                    textBox.AcceptsReturn = true;
                    textBox.AcceptsTab = true;
                    DockPanel.SetDock(textBox, Dock.Left);
                    dockPanel.Children.Add(textBox);

                    ButtonSaveObject button = new ButtonSaveObject(Character.Character.character.items[i], textBox);
                    button.Click += Button_Click1;
                    stackPanel.Children.Add(button);
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
                stackPanel.Children.Add(removeButton);

                DockPanel.SetDock(stackPanel, Dock.Right);
                dockPanel.Children.Add(stackPanel);

                listboxCharacterObjects.Items.Add(dockPanel);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonSave = sender as ButtonSaveObject;
                buttonSave.TextBoxObject.ShouldRewrite = false;
                var @object = buttonSave.Object;
                string[] lines = buttonSave.TextBoxObject.Text.Split('\n');
                if (!lines[0].StartsWith("name: "))
                    throw new Exception("name");
                @object.name = lines[0].Substring("name: ".Length);
                if (!lines[1].StartsWith("description: "))
                    throw new Exception("description");
                @object.description = lines[1].Substring("description: ".Length);
                if (!lines[2].StartsWith("weight: "))
                    throw new Exception("weight");
                @object.weight = float.Parse(lines[2].Substring("weight: ".Length));

                var attributes = new List<string>(lines);
                attributes.RemoveRange(0, 4);
                for (int i = 0; i < @object.attributes.Count; i++)
                {
                    if (!attributes[i].StartsWith("\t"))
                        throw new Exception("\\t");

                    @object.attributes[i].name = attributes[i].Substring(1, attributes[i].Substring(1).IndexOf(':'));
                    @object.attributes[i].value = float.Parse(attributes[i].Substring(attributes[i].IndexOf(':') + 2));
                }
                if (lines.Length-4 > @object.attributes.Count)
                { 
                    attributes.RemoveRange(0, @object.attributes.Count);
                    for (int i = 0; i < @object.attributes.Count; i++)
                    {
                        CharacterAttribute characterAttribute = new CharacterAttribute(
                            attributes[i].Substring(1, attributes[i].Substring(1).IndexOf(':')),
                            float.Parse(attributes[i].Substring(attributes[i].IndexOf(':') + 2)));
                        Handlers.CharacterHandler.AddAttribute(@object, characterAttribute);
                    }
                }
                Refresh();
            }
            catch
            {
                //MessageBox.Show(exception.Message);
                Refresh();
            }
        }

        //private void TextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Key == Key.Enter && false)
        //        {
        //            var textBox = sender as TextBoxObject;
        //            textBox.ShouldRewrite = false;
        //            string[] lines = textBox.Text.Split('\n');
        //            if (!lines[0].StartsWith("name: "))
        //                throw new Exception("name");
        //            textBox.Object.name = lines[0].Substring("name: ".Length);
        //            if (!lines[1].StartsWith("description: "))
        //                throw new Exception("description");
        //            textBox.Object.description = lines[1].Substring("description: ".Length);
        //            if (!lines[2].StartsWith("weight: "))
        //                throw new Exception("weight");
        //            textBox.Object.weight = float.Parse(lines[2].Substring("weight: ".Length));

        //            var attributes = new List<string>(lines);
        //            attributes.RemoveRange(0, 4);
        //            for (int i = 0; i < textBox.Object.attributes.Count; i++)
        //            {
        //                if (!attributes[i].StartsWith("\t"))
        //                    throw new Exception("\\t");

        //                textBox.Object.attributes[i].name = attributes[i].Substring(1, attributes[i].Substring(1).IndexOf(':'));
        //                textBox.Object.attributes[i].value = float.Parse(attributes[i].Substring(attributes[i].IndexOf(':')+2));
        //            }
        //            Refresh();
        //        }
        //    }
        //    catch
        //    {
        //        //MessageBox.Show(exception.Message);
        //        Refresh();
        //    }
        //}

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var list = new List<CharacterAttribute>();
            list.Add(new CharacterAttribute("Attribute1", 1));
            list.Add(new CharacterAttribute("Attribute2", 2));
            CharacterObject characterObject = new CharacterObject("[name]", "[description]", 0f, list);
            Handlers.CharacterHandler.AddObject(Character.Character.character, characterObject);
            Refresh();
            listboxCharacterObjects.ScrollIntoView(listboxCharacterObjects.Items[listboxCharacterObjects.Items.Count-1]);
        }
    }
}
