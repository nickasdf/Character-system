using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Data;
using Character_system.Character;
namespace Character_system.UI
{
    /// <summary>
    /// Interaction logic for CharacterPage.xaml
    /// </summary>
    public partial class CharacterPage : Page
    {

        public CharacterPage()
        {
            InitializeComponent();
        }

        void addObject(List<CharacterAttribute> lst , int  number = 3 )
        {
            for (int i = 0; i < number; i++)
            {
                lst.Add(new CharacterAttribute() { name = "Speed", value = 10 });
                lst.Add(new CharacterAttribute() { name = "ebat", value = 10 });
                lst.Add(new CharacterAttribute() { name = "NIHUASEBE", value = 10 });
            } 
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var attributes = new CharacterStatus().allAttributes;
            foreach(var attribute in attributes)
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
    }
}
