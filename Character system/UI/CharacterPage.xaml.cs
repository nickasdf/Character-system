using System.Windows;
using System.Windows.Controls;

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            /*ListBoxItem listBoxItem = new ListBoxItem();
            
            foreach (var item in Character.Character.character.items)
            {
                listBoxItem.Content = item.ToString();
            }*/
        }
    }
}
