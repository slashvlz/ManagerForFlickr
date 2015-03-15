using System;
using System.Collections.Generic;
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
using FlickrNet;

namespace mrFlickr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OAuthRequestToken requestToken;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Flickr f = fAuth.GetInstance();
            requestToken = f.OAuthGetRequestToken("oob");

            string url = f.OAuthCalculateAuthorizationUrl(requestToken.Token, AuthLevel.Write);

            System.Diagnostics.Process.Start(url);

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           /* if (String.IsNullOrEmpty(verify_app.Text))
            {
                MessageBox.Show("Нужно вставить проверочный код.");
                return;
            }*/

            Flickr f = fAuth.GetAuthInstance();

            GalleryCollection gal_col= f.GalleriesGetList();

            foreach (Gallery gal in gal_col)
            {

            }
            

            try
            {
                string token = "72157649041023933-db370f453929fe76";
                string tokenSecret = "eca4d08ecf331ff5";
                
                string verifier_text="309-033-020"; //verify_app.Text;
                var accessToken = f.OAuthGetAccessToken(token, tokenSecret, verifier_text);
                fAuth.OAuthToken = accessToken;
                FlickrNet.OAuthAccessToken ftoken = new OAuthAccessToken();
                
                this.Title = "Авторизован как " + accessToken.FullName;
            }
            catch (FlickrApiException ex)
            {
                MessageBox.Show("Ошибка авторизации: " + ex.Message);
            }
        }
    }
}
