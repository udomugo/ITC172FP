using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment7_MVC.Models;

namespace Assignment7_MVC.Controllers
{

    public class PersonLController : Controller
    {
        private Community_AssistEntities db = new Community_AssistEntities();
        // GET: PersonL
        public ActionResult Index()
        {
            var peeps = from p in db.People
                        from pa in p.PersonAddresses
                        from c in p.Contacts
                        where c.ContactTypeKey == 1
                        select new
                        {
                            p.PersonKey
                        ,
                            p.PersonLastName
                        ,
                            p.PersonFirstName
                        ,
                            p.PersonEmail
                        ,
                            pa.PersonAddressApt
                        ,
                            pa.PersonAddressStreet
                        ,
                            pa.PersonAddressCity
                        ,
                            pa.PersonAddressState
                        ,
                            pa.PersonAddressZip
                        ,
                            c.ContactNumber
                        };

            List<PersonLite> peepsList = new List<PersonLite>();
            foreach(var p in peeps)
            {
                PersonLite pl = new Models.PersonLite();
                pl.PersonKey = (int)p.PersonKey;
                pl.LastName = (string)p.PersonLastName;
                pl.FirstName = (string)p.PersonFirstName;
                pl.Email = (string)p.PersonEmail;
                pl.Apartment = (string)p.PersonAddressApt;
                pl.Street = (string)p.PersonAddressStreet;
                pl.City = (string)p.PersonAddressCity;
                pl.ZipCode = (string)p.PersonAddressZip;
                peepsList.Add(pl);
            }

            return View(peepsList);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create([Bind(Include ="LastName, FirstName, Email, Password, Apartment, Street, City, State, ZipCode, HomePhone, WorkPhone")]
        PersonLite pl)
        {
            int result = db.usp_Register(pl.LastName, pl.FirstName, pl.Email, pl.Password, pl.Apartment, pl.Street, pl.City, pl.State, pl.ZipCode, pl.HomePhone, pl.WorkPhone);
            return View();
        }
    }
}