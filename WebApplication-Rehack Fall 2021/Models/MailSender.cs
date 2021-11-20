using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Rehack_Fall_2021.Models
{
    public class MailSender
    {
        public static bool SendEmailToUser(string email, string adminName, string adminEmail, string BaseUrl = "")
        {
            try
            {
                string MailBody;
                string text = "<link href='https://fonts.googleapis.com/css?family=Bree+Serif' rel='stylesheet'><style> * {";
                text += "  font-family: 'Bree Serif', serif; }";
                text += " .list-group-item {       border: none;  }  .hor {border-bottom: 5px solid black;}";
                text += " .line {       margin-bottom: 20px; }";
                text = "<html><head></head><body><nav class='navbar navbar-default'><div class='container-fluid'>" +
                             "</div></nav><center><div><h1 class='text-center'>Message From Admin!</h1>" +
                             "<p class='text-bold'>" + "Thank you so much for your interest!" + "</p>" +
                             "<p class='text-bold'>" + "Please, do contact us if you have additional queries.Thanks again!" + "</p><br>" +
                             "<p class='text-right'>" + "Best regards," + "</p>" +
                             "<p class='text-right'>" + adminName + "</p>" +
                             "<p class='text-right'>" + "For further queries, hit this email address: " + adminEmail + "</p>" +
                             "<p class='text-right'>" + "Weapon Store" + "</p>" +
                             "<button style='background-color: rgb(0,174,239);'>" + "<a href='" + BaseUrl + "Home/Index" + "' style='text-decoration:none;font-size:15px;color:white;'>Go Back TO Home page</a>" + "</button>" +
                             "<p style='color:red;'>Please move this mail into your inbox.</p></div></center>";
                text += "<script src = 'https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js' ></ script ></ body ></ html >";
                MailBody = text;
                MailBody = text;
                RestClient client = new RestClient(); //intializing Rest client object 
                client.BaseUrl = new Uri("https://api.mailgun.net/v3"); // this is base url (remains same)
                client.Authenticator = new HttpBasicAuthenticator("api", "key-ff43f744db29071a74f3106541e3b925"); //copy Private Api Key from Api security (https://app.mailgun.com/app/account/security/api_keys)
                RestRequest request = new RestRequest();
                request.AddParameter("domain", "nodlays.co.uk", ParameterType.UrlSegment);  //Create a new domain from side bar "Sending -> Domains -> Add New Domain"
                request.Resource = "{domain}/messages";
                request.AddParameter("from", "info@deiready.com"); //Can be used any email here, without any password requirements
                request.AddParameter("to", email); //email where you want to send mail
                request.AddParameter("subject", "Survey System"); //subject of mail
                request.AddParameter("html", MailBody); //send html code generated above
                request.Method = Method.POST;
                string response = client.Execute(request).Content.ToString();
                if (response != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}