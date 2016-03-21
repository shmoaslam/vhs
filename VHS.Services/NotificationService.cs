using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Services.App_Code;

namespace VHS.Services
{
    public class NotificationService
    {
        string url = ConfigurationManager.AppSettings["URL"].ToString();
        public async void UserRegistration(string Email, string Name)
        {
            try
            {
                string Subject = "";
                string Messaage = "";
                string Links = "<b><a target='_blank' href=" + url + ">Click here to Login.</a></b>";
                //var templateFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views");
               // var templateFilePath = templateFolderPath + "\\Mailer\\EmployeeAccountTemplate.cshtml";
               // var mailDetails = new MailingDetails() { Name =  MailSend.SendEmail(Email, Subject, emailHtmlBody, true);
                //var emailHtmlBody = templateService.Parse(File.ReadAllText(templateFilePath), mailDetails, null, null);
               // MailSend.SendEmail(Email, Subject, emailHtmlBody, true);
                MailSend.SendEmail(Email, Subject, "", true);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
