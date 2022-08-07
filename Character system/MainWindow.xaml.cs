using System.Windows;
using System.Windows.Controls;
using Character_system.Character;
using System.Collections.Generic;
using Character_system.UI;
using System.Windows.Input;

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
            attributes.Add(new CharacterAttribute("agility", 30));
            attributes.Add(new CharacterAttribute("attack", 0.2f));

            items.Add(new CharacterObject("bread", "taste and cool bread", 5.2f, new List<CharacterAttribute>(attributes)));

            attributes.Clear();
            attributes.Add(new CharacterAttribute("strength", 20));
            attributes.Add(new CharacterAttribute("armor", 0.4f));

            items.Add(new CharacterObject("crown", "A gold crown", 2.4f, new List<CharacterAttribute>(attributes)));
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
            
            
            listboxCharacterObjects.Items.Clear();
            foreach (var item in Character.Character.character.items)
            {
                DockPanel dockPanel = new DockPanel();
                dockPanel.LastChildFill = false;
                
                TextBlockObject textBlock = new TextBlockObject(item);
                DockPanel.SetDock(textBlock, Dock.Left);
                dockPanel.Children.Add(textBlock);

                ButtonRemoveObject removeButton = new ButtonRemoveObject(item);
                removeButton.Click += RemoveButton_Click;
                DockPanel.SetDock(removeButton, Dock.Right);
                dockPanel.Children.Add(removeButton);

                listboxCharacterObjects.Items.Add(dockPanel);
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
