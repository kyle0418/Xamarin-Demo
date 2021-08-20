using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDriveDummy
{
    public class GoogleConfig
    {
        public static string scope = "https://www.googleapis.com/auth/userinfo.email";
        //public static string scope = "https://www.googleapis.com/auth/gmail.labels";

        // IOS Test App
        public static readonly string clientId = "225896618697-j0e8st27e2h46cj5dqf406ng0uej323c.apps.googleusercontent.com";
        //public static readonly string redirectUrl = "net.axcrypt.axcrypt2.xamforms:/oauth2redirect";

        public static readonly string redirectUrl = "com.googleusercontent.apps.225896618697-j0e8st27e2h46cj5dqf406ng0uej323c:/oauth2redirect";
    }
}
