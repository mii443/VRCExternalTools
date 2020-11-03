using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VRCExternalTools.VRCAPI;

namespace VRCExternalTools
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<VRCAPIBase.LimitedUserObject> friendsCollection = new ObservableCollection<VRCAPIBase.LimitedUserObject>();
        ObservableCollection<VRCAPIBase.AvatarObject> avatarsCollection = new ObservableCollection<VRCAPIBase.AvatarObject>();
        private VRCAPI.VRCAPI api;
        public MainWindow()
        {
            InitializeComponent();
            friends.ItemsSource = friendsCollection;
            avatars.ItemsSource = avatarsCollection;
            BindingOperations.EnableCollectionSynchronization(this.friendsCollection, new object());
            BindingOperations.EnableCollectionSynchronization(this.avatarsCollection, new object());
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var authenticator = new VRCAuthenticator(userName.Text, password.Password);
            api = authenticator.loginAsync().Result;

            if (api != null && !authenticator.isTwoAuthentication())
            {
                loginButton.IsEnabled = false;
            } else if (api != null && authenticator.isTwoAuthentication())
            {
                var result = authenticator.verifyTwoFactor(int.Parse(oneTimePassword.Text));
                if (result)
                {
                    loginButton.IsEnabled = false;
                    var userConfig = api.getUserConfig();
                    Name.Content = userConfig.username;

                    var avatars = api.searchAvatars(user: "me", releaseStatus: "all");
                    foreach (var avatar in avatars)
                    {
                        avatarsCollection.Add(avatar);
                    }
                }
                else
                {
                    MessageBox.Show("2FA Failed.");
                }
            }
            else if (api == null)
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void reloadFriends_Click(object sender, RoutedEventArgs e)
        {
            if (api != null)
            {
                var friends = api.getFriends(500,true,0);
                friendsCollection.Clear();
                foreach (var friend in friends)
                {
                    friendsCollection.Add(friend);
                }
            }
        }
    }
}
