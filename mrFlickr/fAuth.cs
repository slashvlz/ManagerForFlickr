using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlickrNet;

namespace mrFlickr
{
    class fAuth
    {

        public const string ApiKey = "6955460ccf9ada544467db10027c443e";
        public const string SharedSecret = "cfafac5e2caca114"; //секрет1

        public static Flickr GetInstance()
        {
            return new Flickr(ApiKey, SharedSecret);
        }

        public static Flickr GetAuthInstance()
        {
            var f = new Flickr(ApiKey, SharedSecret);
            f.OAuthAccessToken = OAuthToken.Token;
            f.OAuthAccessTokenSecret = OAuthToken.TokenSecret;
            return f;
        }

        public static OAuthAccessToken OAuthToken
        {
            get
            {
                return Properties.Settings.Default.fOAuthToken;
            }
            set
            {
                Properties.Settings.Default.fOAuthToken = value;
                Properties.Settings.Default.Save();
            }
        }


    }
}
