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
            /*List<Character.CharacterAttribute> allAttributes = new List<Character.CharacterAttribute>();

            allAttributes = new List<CharacterAttribute>();
            addObject(allAttributes,40);
            
            LstAttributes.ItemsSource = allAttributes;*/
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
                listboxCharacterStatus.Items.Add(attribute);
            }

            Button button = new Button();
            button.Width = 200;
            button.Height = 50;
            button.Content = "button";
            button.FontSize = 14;

            listboxCharacterStatus.Items.Add(button);
            

            listboxCharacterObjects.ItemsSource = Character.Character.character.items;
        }
    }
}
