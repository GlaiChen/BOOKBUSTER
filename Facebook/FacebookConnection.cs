using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Facebook;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using BooksStore.Models;

namespace BooksStore.Facebook
{
    public class FacebookConnection
    {
        private const string APP_ID = "765386667376303";
        private const string APP_SECRET = "815b18953d98deccaeb03ef648a28b2d";
        private const string PAGE_ID = "105206751354628";
        private const string ACCESS_TOKEN = "EAAK4HXhsvq8BAP5Nok6OUQ70HcCFf3SKTp0pg1FZBmQsKZBnuQjG9pHQGjwZAXbA1JxfyKp66MH5sdtcZCTcsfDLqBnIZBATsV1yF2d1u2BnyLjKJelpqblAYtfu7MziDZB3EwNBLROK4WPcJBlZAD2faMEuo5k6hlqxRex1Ksm06r1ZAAZBYaHCL";

        public static void PostMessage(Book book)
        {
            string accessToken = ACCESS_TOKEN;
            FacebookClient facebookClient = new FacebookClient(accessToken);

            dynamic messagePost = new ExpandoObject();
            messagePost.access_token = accessToken;
            messagePost.message = "Check out this new amazing book: " + book.BookName;

            string url = string.Format("/{0}/feed", PAGE_ID);
            facebookClient.Post(url, messagePost);
        }
    }
}
