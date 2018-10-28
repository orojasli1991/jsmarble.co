using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using JSMarbleProject.Models;
using log4net;

namespace JSMarbleProject.Controllers
{
    public class HomeController : Controller
    {       
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index(FormCollection form)
        {
            if (Request.HttpMethod == "POST")
            {
                log.Info("entro al ActionResult index");
                if (IndexSend(form))
                {
                    //mensaje confirmacion
                }
                else {
                    log.Error("Error no entro Request.HttpMethod ");
                    //Mensaje de error al enviar el correo
                }
            }
            log.Info("cargando");
            return View();      
        }
        public bool IndexSend(FormCollection form)
        {
            log.Info("entro a IndexSend");
            try
                {
                var viewModel = new FormContact
                {
                    Name = form["name"],
                    Email = form["email"],
                    phone = form["phone"],
                    Subject = form["subject"],
                    Message = form["message"]
                };                
                string server = GetConfigValue("serverSmtp");
                   MailAddress from = new MailAddress(viewModel.Email,viewModel.Name);
                    MailAddress to = new MailAddress(GetConfigValue("EmailSent"),GetConfigValue("NameSent"));
                    MailMessage message = new MailMessage(from, to);
                    message.Subject = viewModel.Subject;
                    message.Body = viewModel.Message;
                    // Add a carbon copy recipient.
                    MailAddress copy = new MailAddress(GetConfigValue("EmailCopy"));
                    message.CC.Add(copy);
                    SmtpClient client = new SmtpClient(server,25);
                    // Include credentials if the server requires them.
                    client.Credentials = new NetworkCredential(GetConfigValue("UserEmail"),GetConfigValue("PasswordEmail"));
                try
                    {
                        client.Send(message);
                    log.Info("Correo enviado: " + message.From + " Server: " + server + " Copy: " + copy);
                    return true;
                    }
                    catch (Exception ex)
                    {
                    log.Error(ex.InnerException.Message);
                    return false;
                    }
                }
                catch (Exception e)
                {
                //log.Error(e.InnerException.Message);
                return false;
                }                 
        }
        public ActionResult MarblePlates()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Floors()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Kitchens()
        {
            return View();
        }
        public ActionResult MarbleTables()
        {
            return View();
        }
        public ActionResult Mouldings()
        {
            return View();
        }
        public ActionResult Sinks()
        {
            return View();
        }
        public ActionResult RusticBars()
        {
            return View();
        }
        public ActionResult Chimneys()
        {
            return View();
        }
        public ActionResult Columns()
        {
            return View();
        }
        private String GetConfigValue(String key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}