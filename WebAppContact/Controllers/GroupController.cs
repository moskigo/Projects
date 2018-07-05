using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAppContact.Models;

namespace WebAppContact.Controllers
{
    public class GroupController : Controller
    {
        DbModel model = new DbModel();

      
        
        public ActionResult Contacts()
        {
            var email = Request.QueryString["email"];
            var id = Request.QueryString["id"];

            if (email == null || id == null || email == String.Empty || id == String.Empty)
                return View("ParamError");
            int ID;
            try
            {
                ID = Convert.ToInt32(id);
            }catch(Exception ex)
            {
                return View("ParamError");
            }

            try
            {
                var isExist = model.Contacts.Where(a=>a.ContactNo == ID && a.Email == email);
                
                if (isExist.Count() == 0)
                {
                    return View("ParamError");
                }
                var contacts = model.Contacts.Where(a => a.Email == email).ToList();
                ViewBag.pattern = @"[a-zA-Z0-9._\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,4}";
                return View(contacts);
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult SaveChange(List<Contact> con)
        {
            DateTime date = DateTime.Now;

            var uid = Request.QueryString["uid"];
            var newEmail = Request["newEmail"];
            var contactId = Request["id"];
            var email = Request["email"];
            var mainRadio = Request["main"];
            var OldContact = Request["OldContact"];
            var newFName = Request["newFName"];
            var newLName = Request["newLName"];

            var listId = contactId.Split(',');
            var listEmail = newEmail.Split(',');
            var MainId = Convert.ToInt32(mainRadio);
            var listOld = (OldContact==null? null: OldContact.Split(','));
            var newFNames = newFName.Split(',');
            var newLNames = newLName.Split(',');

            var listContacts = model.Contacts;

            try
            {
                for (int i = 0; i < listId.Length; i++)
                {
                    var contact = listContacts.Find(Convert.ToInt32(listId[i]));
                    contact.EmailContact = listEmail[i];
                    contact.ModifiedDate = date;
                    contact.Deleted = listOld == null? false: listOld.Contains(contact.ID.ToString());
                    contact.MainContact = contact.ID == MainId;
                    if(newFNames[i] != String.Empty)
                        contact.NewFirstName = newFNames[i];
                    if (newLNames[i] != String.Empty)
                        contact.NewLastName = newLNames[i];
                }
                
                model.SaveChanges();
                return View();
            }
            catch (Exception atr)
            {
                ViewBag.error = atr.Message;
                return View("Error");
            }
        }
    }

}
