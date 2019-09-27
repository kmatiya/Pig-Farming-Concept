using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Livetock_Farm_Management.Models;
using Open_Chequelist_Template.Models;
using fieldState = Livetock_Farm_Management.Models.fieldState;
using input = Livetock_Farm_Management.Models.input;
using outSourcedPig = Livetock_Farm_Management.Models.outSourcedPig;
using pig = Livetock_Farm_Management.Models.pig;
using pigRelationship = Livetock_Farm_Management.Models.pigRelationship;
using productType = Livetock_Farm_Management.Models.productType;
using sale = Livetock_Farm_Management.Models.sale;
using supplier = Livetock_Farm_Management.Models.supplier;
using systemRole = Livetock_Farm_Management.Models.systemRole;
using user = Livetock_Farm_Management.Models.user;

namespace Livetock_Farm_Management.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        myfarmEntities db = new myfarmEntities();
        public ActionResult Index()
        {
            return View(db.sexes);
        }
        public ActionResult AllPigs()
        {
            return View(db.pigs);
        }

        ///Add views
        public ActionResult SickPigs()
        {
            return View(db.pigs.Where(u=>u.pigState.state == "Sick"));
        }
        public ActionResult DeadPigs()
        {
            return View(db.pigs.Where(u => u.pigState.state == "Dead"));
        }
        private List<SelectListItem> loadPigSex()
        {
            List<SelectListItem> sexes = new List<SelectListItem>();
            foreach(sex e in db.sexes)
            {
                sexes.Add(new SelectListItem { Text = e.sexName, Value = e.sexID.ToString() });
            }
            return sexes;
        }
        private List<SelectListItem> loadPigStates()
        {
            List<SelectListItem> states = new List<SelectListItem>();
            foreach(pigState e in db.pigStates)
            {
                states.Add(new SelectListItem { Text = e.state, Value = e.pigStateID.ToString() });
            }
            return states;
        }
        private List<SelectListItem> loadPigSources()
        {
            List<SelectListItem> sources = new List<SelectListItem>();
            foreach(var e in db.pigSources)
            {
                sources.Add(new SelectListItem { Text = e.sourceName, Value = e.sourceID.ToString()});
            }
            return sources;
        }
        private List<SelectListItem> loadsuppliers()
        {
            List<SelectListItem> supplier = new List<SelectListItem>();
            
            foreach (var e in db.suppliers)
            {
                supplier.Add(new SelectListItem { Text = e.supplierName, Value = e.supplierID.ToString() });
            }
            supplier.Add(new SelectListItem { Text = "Add Supplier", Value = "Add Supplier" });
            
            return supplier;
        }
        private List<SelectListItem> loadActivePigs()
        {
            List<SelectListItem> Pigs = new List<SelectListItem>();
            foreach (pig e in db.pigs.Where(u => u.pigState.state != "Sold" || u.pigState.state != "Dead"))
            {
                Pigs.Add(new SelectListItem { Text = e.tagNumber, Value = e.pigNumber.ToString() });
            }
            return Pigs;
        }
        private List<SelectListItem> loadPigs()
        {
            List<SelectListItem> Pigs = new List<SelectListItem>();
            Pigs.Add(new SelectListItem { Text = "Unknown", Value = "" });
            foreach (pig e in db.pigs)
            {
                Pigs.Add(new SelectListItem { Text = e.tagNumber, Value = e.pigNumber.ToString() });
            }
            return Pigs;
        }
            private List<SelectListItem> loadMalePigs()
        {
            List<SelectListItem> MalePigs = new List<SelectListItem>();
            MalePigs.Add(new SelectListItem { Text = "Unknown", Value = "Unknown" });
            foreach (pig e in db.pigs.Where(u => u.sex.sexName == "Male")) 
            {
                MalePigs.Add(new SelectListItem { Text = e.tagNumber, Value = e.pigNumber.ToString()});
            }
            return MalePigs;
        }
        private List<SelectListItem> loadFemalePigs()
        {
            List<SelectListItem> FemalePigs = new List<SelectListItem>();
            FemalePigs.Add(new SelectListItem { Text = "Unknown", Value = "Unknown" });
            foreach (pig e in db.pigs.Where(u => u.sex.sexName == "Female"))
            {
                FemalePigs.Add(new SelectListItem { Text = e.tagNumber, Value = e.pigNumber.ToString() });
            }
            
            return FemalePigs;
            
        }
        private List<SelectListItem> loadFieldStates()
        {
            List<SelectListItem> states = new List<SelectListItem>();
            foreach (fieldState e in db.fieldStates)
            {
                states.Add(new SelectListItem { Text = e.state, Value = e.fieldStatusID.ToString() });
            }
            return states;
        }
        public ActionResult AddPigs()
        {
            loadPigDropDownList();
            productType pig = new productType();
            pigModel toBeCreated = new pigModel();
            toBeCreated.dateOfAcquisition = DateTime.Now;
            return View(toBeCreated);
        }

        private void loadPigDropDownList()
        {
            ViewBag.pigSex = loadPigSex();
            ViewBag.status = loadPigStates();
            ViewBag.source = loadPigSources();
            ViewBag.supplierID = loadsuppliers();
            ViewBag.motherID = loadFemalePigs();
            ViewBag.fatherID = loadMalePigs();
        }

        [HttpPost]
        public ActionResult AddPigs(pigModel pigToAdd)
        {

            pig newPig = new pig();
            pigRelationship newPigRelationship = new pigRelationship();
            pig checkTagNumber = db.pigs.Where(u=>u.tagNumber == pigToAdd.tagNumber).FirstOrDefault();
            if (checkTagNumber != null)
            {
                loadPigDropDownList();
                ViewBag.Message = "Tag number " + pigToAdd.tagNumber.ToString() + " already exist, please assign a unique tag";
                return View(pigToAdd);
            }
            if (pigToAdd.source == 1)
            {               
                newPig = AddPigDetails(pigToAdd, newPig);
                newPig.source = pigToAdd.source;
                if (pigToAdd.fatherID != "Unknown")
                {
                    newPigRelationship.malePig = Convert.ToInt32(pigToAdd.fatherID);
                }
                if (pigToAdd.motherID != "Unknown")
                {
                    newPigRelationship.femalePig = Convert.ToInt32(pigToAdd.motherID);
                }

                db.pigs.Add(newPig);
                //db.SaveChanges();
                //pig newlyAddedPig = db.pigs.Single(u => u.tagNumber == newPig.tagNumber);
                newPigRelationship.siblings = Convert.ToInt32(newPig.pigNumber);
                newPigRelationship.status = 1;
                db.pigRelationships.Add(newPigRelationship);
                db.SaveChanges();
                return RedirectToAction("AllPigs");
            }
            else if(pigToAdd.source == 2)
            {
                newPig = AddPigDetails(pigToAdd, newPig);
                newPig.source = pigToAdd.source;
                db.pigs.Add(newPig);
                

                //pig newlyAddedPig = db.pigs.Single(u => u.tagNumber == newPig.tagNumber);
                input boughtPig = new input();
                boughtPig.product = 1;
                boughtPig.costPerProduct = pigToAdd.buyingPrice;
                boughtPig.numberOfProducts = 1;
                boughtPig.total = pigToAdd.buyingPrice;
                boughtPig.date = Convert.ToDateTime(pigToAdd.dateOfAcquisition.ToShortDateString());
                boughtPig.userID = 1;
                boughtPig.status = 1;
                boughtPig.pigID = newPig.pigNumber;
                db.inputs.Add(boughtPig);
                
                supplier newSupplier = new supplier();
               
                if (pigToAdd.supplierID == "Add Supplier")
                {
                    newSupplier.supplierName = pigToAdd.supplierName;
                    newSupplier.supplierEmail = pigToAdd.supplierEmail;
                    newSupplier.supplierPhoneNumber = pigToAdd.supplierPhoneNumber;
                    newSupplier.supplierState = 1;
                    newSupplier.outSourcedPigs.Add(new outSourcedPig() { pigNumber = newPig.pigNumber, status = 1 });
                    db.suppliers.Add(newSupplier);
                }
                else
                {
                    db.outSourcedPigs.Add(new outSourcedPig() { supplierID = Convert.ToInt32(pigToAdd.supplierID),pigNumber = newPig.pigNumber, status = 1 });
                }
                if (pigToAdd.fatherID != "Unknown")
                {
                    newPigRelationship.malePig = Convert.ToInt32(pigToAdd.fatherID);
                }
                if (pigToAdd.motherID != "Unknown")
                {
                    newPigRelationship.femalePig = Convert.ToInt32(pigToAdd.motherID);
                }
                newPigRelationship.siblings = Convert.ToInt32(newPig.pigNumber);
                newPigRelationship.status = 1;
                db.pigRelationships.Add(newPigRelationship);
                db.SaveChanges();
                return RedirectToAction("AllPigs");
            }
            return View();
        }

        private static pig AddPigDetails(pigModel pigToAdd, pig newPig)
        {
            newPig.tagNumber = pigToAdd.tagNumber;
            newPig.pigColor = pigToAdd.pigColor;
            newPig.pigSex = pigToAdd.pigSex;
            newPig.description = pigToAdd.description;
            newPig.status = pigToAdd.status;
            newPig.dateOfAcquisition = pigToAdd.dateOfAcquisition;
            newPig.approximateAgeInMonths = pigToAdd.approximateAgeInMonths;
            newPig.approximateAgeInYears = pigToAdd.approximateAgeInYears;
            return newPig;
        }

        public ActionResult FamilyTree()
        {
           

            return View(db.pigRelationships.OrderByDescending(u => u.femalePig));
        }
        public ActionResult StockingTaking()
        {
            return View();
        }
        public ActionResult Suppliers()
        {
            return View(db.suppliers);
        }
        [HttpGet]
        public ActionResult AddSupplier()
        {
            ViewBag.supplierState = loadFieldStates();
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(supplier newSupplier)
        {
            if(ModelState.IsValid)
            {
                db.suppliers.Add(newSupplier);
                db.SaveChanges();
                return RedirectToAction("Suppliers");
            }
            ViewBag.supplierState = loadFieldStates();
            return View();
        }
        [HttpGet]
        public ActionResult EditSupplier(int id)
        {
            supplier toBeEdited = db.suppliers.FirstOrDefault(u => u.supplierID == id);
            ViewBag.supplierState = loadFieldStates();
            return View(toBeEdited);
        }
        [HttpPost]
        public ActionResult EditSupplier(supplier updated)
        {
            supplier toBeEdited = db.suppliers.FirstOrDefault(u => u.supplierID == updated.supplierID);
            toBeEdited.supplierName = updated.supplierName;
            toBeEdited.supplierPhoneNumber = updated.supplierPhoneNumber;
            toBeEdited.supplierEmail = updated.supplierEmail;
            toBeEdited.supplierState = updated.supplierState;
            db.SaveChanges();
            return RedirectToAction("Suppliers");
        }
        [HttpGet]
        public ActionResult SupplierDetails(int id)
        {
            supplier supplierInformation = db.suppliers.FirstOrDefault(u => u.supplierID == id);
            return View(supplierInformation);
        }
            public ActionResult PigSummary()
        {
            return View();
        }
        public ActionResult Expenses()
        {
            return View(db.inputs);
        }
        private List<SelectListItem> loadProducts()
        {
            List<SelectListItem> products = new List<SelectListItem>();
            foreach (Livetock_Farm_Management.Models.productType e in db.productTypes)
            {
                products.Add(new SelectListItem { Text = e.type, Value = e.productTypeID.ToString() });
            }

            return products;

        }
        private List<SelectListItem> loadUsers()
        {
            List<SelectListItem> users = new List<SelectListItem>();
            foreach (user e in db.users)
            {
                users.Add(new SelectListItem { Text = e.firstName+ " "+ e.lastName, Value = e.userID.ToString() });
            }

            return users;
        }
        [HttpGet]
        public ActionResult AddExpense()
        {
            ViewBag.product = loadProducts();
            ViewBag.userID = loadUsers();
            ViewBag.status = loadFieldStates();
            ViewBag.pigID = loadPigs();
            return View();
        }
        [HttpPost]
        public ActionResult AddExpense(input newExpense)
        {
            if(ModelState.IsValid)
            {
                db.inputs.Add(newExpense);
                db.SaveChanges();
                RedirectToAction("Expenses");
            }
            ViewBag.product = loadProducts();
            ViewBag.userID = loadUsers();
            ViewBag.status = loadFieldStates();
            ViewBag.pigID = loadPigs();
            return View(newExpense);
        }
        public ActionResult ExpenseSummary()
        {
            return View();
        }
        public ActionResult AllSales()
        {
            
            return View(db.sales);
        }
        [HttpGet]
        public ActionResult AddASale()
        {
            ViewBag.pigNumber = loadActivePigs();
            ViewBag.userID = loadUsers();
            ViewBag.status = loadFieldStates();
            ViewBag.customerID = loadCustomers();
            return View();
        }
        [HttpPost]
        public ActionResult AddASale(sale newSale)
        {
            if(ModelState.IsValid)
            {

                pig soldPig = db.pigs.Find(newSale.pigNumber);
                soldPig.pigState.state = "Sold";
                db.sales.Add(newSale);
                db.SaveChanges();

                return RedirectToAction("AllSales");
            }
            ViewBag.pigNumber = loadActivePigs();
            ViewBag.userID = loadUsers();
            ViewBag.status = loadFieldStates();
            ViewBag.customerID = loadCustomers();
            return View(newSale);
        }
        [HttpGet]
        public ActionResult AllCustomers()
        {
            return View(db.customers);
        }
        [HttpGet]
        public ActionResult AddACustomer()
        {
            ViewBag.typeOfCustomer = loadCustomerTypes();
            return View();
        }

        [HttpPost]
        public ActionResult AddACustomer(customer newCustomer)
        {
            if(ModelState.IsValid)
            {
                db.customers.Add(newCustomer);
                db.SaveChanges();
                return RedirectToAction("AllCustomers");
            }
            ViewBag.typeOfCustomer = loadCustomerTypes();
            return View();
        }
        private List<SelectListItem> loadCustomerTypes()
        {
            List<SelectListItem> types = new List<SelectListItem>();
            foreach(var type in db.customerTypes)
            {
                types.Add(new SelectListItem { Text = type.type, Value = type.customerTypeID.ToString() });
            }
            return types;
        }
        private List<SelectListItem> loadCustomers()
        {
            List<SelectListItem> customers = new List<SelectListItem>();
            foreach(var customer in db.customers)
            {
                customers.Add(new SelectListItem { Text = customer.customerName, Value = (customer.customerID).ToString()});
            }
            return customers;
        }
        public ActionResult SalesSummary()
        {
            return View();
        }
        public ActionResult AllUsers()
        {
            return View(db.users);
        }
        private List<SelectListItem> loadUserRoles()
        {
            List<SelectListItem> userRoles = new List<SelectListItem>();
            foreach (systemRole userRole in db.systemRoles)
            {
                userRoles.Add(new SelectListItem { Text = userRole.roleName, Value = userRole.systemRoleID.ToString() });
            }

            return userRoles;
        }
        [HttpGet]
        public ActionResult AddAUser()
        {
            ViewBag.role = loadUserRoles();
            return View();
        }
        [HttpPost]
        public ActionResult AddAUser(user newUser)
        {
            HashPassword newPassword = new HashPassword();
            if(ModelState.IsValid)
            {
                newUser.password = newPassword.createHashedPassword(newUser.password);
                newUser.passwordSalt = newPassword.salt;
                db.users.Add(newUser);
                db.SaveChanges();
            }
            ViewBag.role = loadUserRoles();
            return View(newUser);
        }
        public ActionResult UserProfile()
        {

            return View();
        }
        public ActionResult UserSummary()
        {
            return View();
        }
    }
}