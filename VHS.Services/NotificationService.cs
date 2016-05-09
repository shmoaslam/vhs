using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Core;
using VHS.Interface;
using VHS.Repository;
using VHS.Services.App_Code;
using VHS.Services.Models;
using VHS.Services.ViewModel;

namespace VHS.Services
{
    public class NotificationService : INotificationService
    {
        private readonly UnitOfWork _unitOfWork;

        string url = ConfigurationManager.AppSettings["URL"].ToString();
        private readonly string _emailFrom = ConfigurationManager.AppSettings["MailFrom"].ToString();
        public NotificationService()
        {
            _unitOfWork = new UnitOfWork();
        }
        public void UserRegistration(string Email, string Name)
        {
            try
            {
                string Subject = "";
                string Messaage = "";
                string Links = "<b><a target='_blank' href=" + url + ">Click here to Login.</a></b>";
                //var templateFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views");
                //var templateFilePath = templateFolderPath + "\\Mailer\\EmployeeAccountTemplate.cshtml";
                //var mailDetails = new MailingDetails() { Name = MailSend.SendEmail(Email, Subject, emailHtmlBody, true);
                //var emailHtmlBody = templateService.Parse(File.ReadAllText(templateFilePath), mailDetails, null, null);
                //MailSend.SendEmail(Email, Subject, emailHtmlBody, true);
                //MailSend.SendEmail(Email, Subject, "", true);
                MailSend.SendGmail(Email, Subject, Links);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void SendBookingRequestMail(BookingRequestViewModel viewModel)
        {
            try
            {
                string Subject = "Booking request received";
                var templateFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views");
                var templateFilePath = templateFolderPath + "\\Mailer\\BookingRequestEmailTemplate.cshtml";
                var templateService = new TemplateService();
                var emailHtmlBody = templateService.Parse(File.ReadAllText(templateFilePath), viewModel, null, null);
                MailSend.SendEmail("info@velvetthomestays.com", Subject, emailHtmlBody, true);
            }
            catch (Exception ex)
            {
                
            }
        }

        public void RmAccountCreation(string Email, string Name, int RMId)
        {
            try
            {
                //Adding Link
                var mailLinkcreate = new MailLink();
                mailLinkcreate.Name = "RM Password creation";
                mailLinkcreate.ExpiryDate = DateTime.Now;
                mailLinkcreate.Email = Email;
                mailLinkcreate.Linkused = false;
                _unitOfWork.MailLinkRepository.Insert(mailLinkcreate);
                _unitOfWork.Save();

                string Subject = "Account Password creation";
                var links = url + "/Account/RMConfirmation?ID=" + Security.Encrypt(mailLinkcreate.id.ToString());
                string Links = "<b><a target='_blank' href=" + links + ">Click here to Change password and Activate account.</a></b>";
                var templateFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Views");
                var templateFilePath = templateFolderPath + "\\Mailer\\MailerTemplate.cshtml";
                var templateService = new TemplateService();
                var mailDetails = new RMCreationMailer() { Name = Name, Link = Links, Description = "Click link to generate password and activate account." };
                var emailHtmlBody = templateService.Parse(File.ReadAllText(templateFilePath), mailDetails, null, null);
                MailSend.SendEmail(Email, Subject, emailHtmlBody,true);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void SendForgotPasswordEmail(string email, string subject, string body)
        {
            MailSend.SendEmail(email, subject, body, true);
        }
    }
}
