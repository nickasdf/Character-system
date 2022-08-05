using Character_system.Character;
using System.Windows.Controls;


namespace Character_system.UI
{
    internal class TextBlockObject : TextBlock
    {
        public CharacterObject Object { get; set; }
        public bool ShouldRewrite { get; set; }
        public TextBlockObject(CharacterObject @object)
        {
            Object = @object;
            Text = Object.ToString();
            FontSize = 20;
            ShouldRewrite = false;
        }
    }
}
