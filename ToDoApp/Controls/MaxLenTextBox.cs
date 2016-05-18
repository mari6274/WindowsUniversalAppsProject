using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace ToDoApp.Controls
{
    public sealed class MaxLenTextBox : TextBox
    {
        public MaxLenTextBox()
        {
            DefaultStyleKey = typeof (TextBox);
            TextChanged += HandleTextChanged;
        }

        public bool Valid { get; private set; } = true;

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (MaxLenTextBox) sender;
            if (textBox.Text.Length > 40)
            {
                textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                Valid = false;
            }
            else
            {
                textBox.BorderBrush = new SolidColorBrush(Colors.Blue);
                Valid = true;
            }
        }
    }
}