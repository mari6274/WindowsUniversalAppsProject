using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App6
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LocalSettingsPage : Page
    {
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;

        public LocalSettingsPage()
        {
            InitializeComponent();
            var text = (string) _localSettings.Values["text"];
            if (text != null)
            {
                MyTextBox.Text = text;
            }
        }

        private void SaveText_OnClick(object sender, RoutedEventArgs e)
        {
            _localSettings.Values["text"] = MyTextBox.Text;
        }
    }
}