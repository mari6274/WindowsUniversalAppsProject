using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ToDoApp.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private readonly ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        private readonly UserNameVm _userNameVm;

        private const string UserNameKey = "user_name";

        public LoginPage()
        {
            this.InitializeComponent();
            _userNameVm = VmLocator.UserNameVm;
            DataContext = _userNameVm;
            var userName = (string)_localSettings.Values[UserNameKey];
            if (userName != null)
            {
                _userNameVm.UserName = userName;
            }
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            _localSettings.Values[UserNameKey] = _userNameVm.UserName;
            Frame.Navigate(typeof(TasksPage));
        }
    }
}
