using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using VRCExternalTools.VRCAPI;

namespace VRCExternalTools
{
    /// <summary>
    /// avatarWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class avatarWindow : Window
    {
        private VRCAPI.VRCAPI api;
        private VRCAPIBase.AvatarObject avatar;

        public avatarWindow(VRCAPI.VRCAPI vrcApi, VRCAPIBase.AvatarObject currentAvatar)
        {
            api = vrcApi;
            avatar = currentAvatar;
            InitializeComponent();

            this.Title = avatar.name;
            idLabel.Content = avatar.id;
            nameLabel.Content = avatar.name;
            descriptionLabel.Content = avatar.description;
            versionLabel.Content = avatar.version.ToString();
            featuredLabel.Content = avatar.featured.ToString();
            created_atLabel.Content = avatar.created_at;
            updated_atLabel.Content = avatar.updated_at;
            releaseStatusLabel.Content = avatar.releaseStatus;
            platformLabel.Content = avatar.platform;
        }

        private void downloadPackageButton_Click(object sender, RoutedEventArgs e)
        {
            var perfectAvatar = api.getAvatarById(avatar.id);

            var dialog = new SaveFileDialog();
            dialog.Filter = "Unity package file(*.unitypackage)|*.unitypackage";
            dialog.FileName = perfectAvatar.name + ".unitypackage";

            var result = dialog.ShowDialog() ?? false;
            if (!result)
            {
                return;
            }

            var client = new WebClient();
            client.DownloadFile(perfectAvatar.unityPackageUrl, dialog.FileName);
        }
    }
}
