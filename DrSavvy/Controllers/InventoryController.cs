using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrSavvy.Models;

namespace DrSavvy.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        // Supplier Controller Functions
        public ActionResult SearchSupplier()
        {
            DrSavvyEntities db = new DrSavvyEntities();

            List<SupplierClass> list = db.Suppliers.Select(x => new SupplierClass { Supplier_ID = x.Supplier_ID, SupplierName = x.SupplierName, SupplierEmail=x.SupplierEmail, SupplierAddress =x.SupplierAddress,SupplierContactPerson=x.SupplierContactPerson,SupplierCellNumber=x.SupplierCellNumber,SupplierWorkNumber=x.SupplierWorkNumber}).ToList();
            ViewBag.ProdList = list;
            return View();
        }

        [HttpPost]
        public ActionResult SearchSupplier(SupplierClass model)
        {
            try
            {
                DrSavvyEntities db = new DrSavvyEntities();
                List<SupplierClass> list = db.Suppliers.Select(x => new SupplierClass { Supplier_ID = x.Supplier_ID, SupplierName = x.SupplierName, SupplierEmail = x.SupplierEmail, SupplierAddress = x.SupplierAddress, SupplierContactPerson = x.SupplierContactPerson, SupplierCellNumber = x.SupplierCellNumber, SupplierWorkNumber = x.SupplierWorkNumber }).ToList();
                ViewBag.ProdList = list;

                if (model.Supplier_ID > 0)
                {
                    if (ModelState.IsValid == true)
                    {
                        //update
                        Supplier prod = db.Suppliers.SingleOrDefault(x => x.Supplier_ID == model.Supplier_ID);
                        prod.Supplier_ID = model.Supplier_ID;
                        prod.SupplierName = model.SupplierName;
                        prod.SupplierEmail = model.SupplierEmail;
                        prod.SupplierAddress = model.SupplierAddress;
                        prod.SupplierCellNumber = model.SupplierCellNumber;
                        prod.SupplierContactPerson = model.SupplierContactPerson;
                        prod.SupplierWorkNumber = model.SupplierWorkNumber;
                        db.Suppliers.Add(prod);
                        db.SaveChanges();
                    }



                }
                else
                {
                    if (ModelState.IsValid == true)
                    {
                        //Insert
                        Supplier prod = new Supplier();
                        prod.SupplierName = model.SupplierName;
                        prod.SupplierEmail = model.SupplierEmail;
                        prod.SupplierAddress = model.SupplierAddress;
                        prod.SupplierCellNumber = model.SupplierCellNumber;
                        prod.SupplierContactPerson = model.SupplierContactPerson;
                        prod.SupplierWorkNumber = model.SupplierWorkNumber;
                        db.Suppliers.Add(prod);
                        db.SaveChanges();
                    }


                }
                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult AddEditSupplier(int SupplierId)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            List<SupplierClass> list = db.Suppliers.Select(x => new SupplierClass { Supplier_ID = x.Supplier_ID, SupplierName = x.SupplierName, SupplierEmail = x.SupplierEmail, SupplierAddress = x.SupplierAddress, SupplierContactPerson = x.SupplierContactPerson, SupplierCellNumber = x.SupplierCellNumber, SupplierWorkNumber = x.SupplierWorkNumber }).ToList();
            ViewBag.ProdList = list;
            SupplierClass model = new SupplierClass();

            if (SupplierId > 0)
            {

                Supplier prod = db.Suppliers.FirstOrDefault(x => x.Supplier_ID == SupplierId);
                model.Supplier_ID = prod.Supplier_ID;
                model.SupplierName = prod.SupplierName;
                model.SupplierEmail = prod.SupplierEmail;
                model.SupplierAddress = prod.SupplierAddress;
                model.SupplierCellNumber = prod.SupplierCellNumber;
                model.SupplierContactPerson = prod.SupplierContactPerson;
                model.SupplierWorkNumber = prod.SupplierWorkNumber;

            }

            return PartialView("SupplierPartial", model);

        }



        //Product Type Controller Functions
        public ActionResult SearchProductType()
        {
            DrSavvyEntities db = new DrSavvyEntities();

            List<Product_TypeClass> list = db.Product_Type.Select(x => new Product_TypeClass { Product_Type_ID = x.Product_Type_ID, Product_Type_Description = x.Product_Type_Description }).ToList();
            ViewBag.ProdTypeList = list;

            return View();
        }


        [HttpPost]
        public ActionResult SearchProductType(Product_TypeClass model)
        {
            try
            {
                bool status = false;
                DrSavvyEntities db = new DrSavvyEntities();
                List<Product_TypeClass> list = db.Product_Type.Select(x => new Product_TypeClass { Product_Type_ID = x.Product_Type_ID, Product_Type_Description = x.Product_Type_Description }).ToList();
                ViewBag.ProdTypeList = list;
                if(ModelState.IsValid)
                { 
                if (model.Product_Type_ID > 0)
                {
                     
                        //update
                        Product_Type prod = db.Product_Type.SingleOrDefault(x => x.Product_Type_ID == model.Product_Type_ID);
                        prod.Product_Type_ID = model.Product_Type_ID;
                        prod.Product_Type_Description = model.Product_Type_Description;                    
                        db.SaveChanges();
                       



                }
                else
                {
                    
                        //Insert
                        Product_Type prod = new Product_Type();
                        prod.Product_Type_Description = model.Product_Type_Description;
                        db.Product_Type.Add(prod);
                        db.SaveChanges();
                    
                    

                }
                    status = true;
                return View(model);
                }
                return new JsonResult { Data = new { status =status } };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public JsonResult DeleteProdType(int ProductTypeId)
        {
            DrSavvyEntities db = new DrSavvyEntities();

            bool result = false;
            Product_Type prod = db.Product_Type.FirstOrDefault(x => x.Product_Type_ID == ProductTypeId);
            if (prod != null)
            {
                db.Product_Type.Remove(prod);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEditProdType(int ProductTypeId)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            List<Product_TypeClass> list = db.Product_Type.Select(x => new Product_TypeClass { Product_Type_ID = x.Product_Type_ID, Product_Type_Description = x.Product_Type_Description }).ToList();
            ViewBag.ProdTypeList = list;
            Product_TypeClass model = new Product_TypeClass();

            if (ProductTypeId > 0)
            {

                Product_Type prod = db.Product_Type.FirstOrDefault(x => x.Product_Type_ID == ProductTypeId);
                model.Product_Type_ID = prod.Product_Type_ID;
                model.Product_Type_Description = prod.Product_Type_Description;


            }

            return PartialView("ProdTypePartial", model);

        }









        // Product Controller Functions
        public ActionResult SearchProduct()
        {
            DrSavvyEntities db = new DrSavvyEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<Supplier> list = db.Suppliers.ToList();
            ViewBag.SupplierList = new SelectList(list, "Supplier_ID", "SupplierName");
            List<ProductClass> listprod = db.Products.Select(x => new ProductClass { ProductID = x.ProductID, ProductName = x.ProductName, Product_Type_Description = x.Product_Type.Product_Type_Description, Product_Disable = x.Product_Disable, Product_Qty = x.Product_Qty, Supplier_ID = x.Supplier.Supplier_ID, SupplierName = x.Supplier.SupplierName, Product_Type_ID = x.Product_Type_ID, Price_Figure = db.Prices.Where(s => s.ProductID == x.ProductID).Select(p => p.Price_Figure).FirstOrDefault()}).ToList();
            ViewBag.ProdList = listprod;
            return View();
        }

        [HttpPost]
        public ActionResult SearchProduct(ProductClass model)
        {
            try
            {

                DrSavvyEntities db = new DrSavvyEntities();
                db.Configuration.ProxyCreationEnabled = false;
                List<Supplier> list = db.Suppliers.ToList();
                ViewBag.SupplierList = new SelectList(list, "Supplier_ID", "SupplierName");
                List<ProductClass> listprod = db.Products.Select(x => new ProductClass { ProductID = x.ProductID, ProductName = x.ProductName, Product_Type_Description = x.Product_Type.Product_Type_Description, Product_Disable = x.Product_Disable, Product_Qty = x.Product_Qty, Supplier_ID = x.Supplier.Supplier_ID, SupplierName = x.Supplier.SupplierName, Product_Type_ID = x.Product_Type_ID, Price_Figure = db.Prices.Where(s => s.ProductID == x.ProductID).Select(p => p.Price_Figure).FirstOrDefault() }).ToList();
                ViewBag.ProdList = listprod;
                bool status = false;
                if (ModelState.IsValid == true)
                {

                
                if (model.ProductID> 0)
                {
                    
                        //update
                        Product prod = db.Products.SingleOrDefault(x => x.ProductID == model.ProductID);
                        prod.Supplier_ID = model.Supplier_ID;
                        prod.ProductName = model.ProductName;
                        prod.Product_Type_ID = model.Product_Type_ID;
                        db.SaveChanges();



                        status = true;
                }
                else
                {

                        //Insert
                        List <string> invie = db.Products.Select(z => z.ProductName).ToList();
                        int v = invie.Count();
                        int i = 0;
                        bool test = false;
                        string pname = model.ProductName;
                        while ( i < v){

                            if(pname.ToLower() == invie[i].ToLower())
                            {
                                test = true;
                                i = v;
                            }
                            else
                            {
                                i++;
                            }
                        }
                        if (test == false) { 
                        Product prod = new Product();
                        Price pri = new Price();
                        prod.Supplier_ID = model.Supplier_ID;
                        prod.ProductName = model.ProductName;
                        prod.Product_Type_ID = model.Product_Type_ID;
                        prod.Product_Disable = false;
                        prod.Product_Qty = 0;
                        db.Products.Add(prod);
                        db.SaveChanges();
                        Price pric = new Price();
                        pric.Price_Figure = Convert.ToDecimal(model.Price_Figure);
                        pric.Date_Initiated = DateTime.Now;
                        int idd = db.Products.Where(x => x.ProductName == model.ProductName).Select(x => x.ProductID).FirstOrDefault();
                        pric.ProductID = idd;
                        db.Prices.Add(pric);
                        db.SaveChanges();
                    
                        }

                        status = test;
                    }
                    
               
                 }
                return new JsonResult { Data = new { stat = status } };
            }
            catch (Exception ex)
            {

                return View(ex);
            }

        }

        public ActionResult AddEditProduct(int ProductId)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<Product_Type> plist = db.Product_Type.ToList();
            ViewBag.ProdTypeList = new SelectList(plist, "Product_Type_ID", "Product_Type_Description");
            List<Supplier> list = db.Suppliers.ToList();
            ViewBag.SupplierList = new SelectList(list, "Supplier_ID", "SupplierName");
            List<ProductClass> listprod = db.Products.Select(x => new ProductClass { ProductID = x.ProductID, ProductName = x.ProductName, Product_Type_Description = x.Product_Type.Product_Type_Description, Product_Disable = x.Product_Disable, Product_Qty = x.Product_Qty, Supplier_ID = x.Supplier.Supplier_ID, SupplierName = x.Supplier.SupplierName, Product_Type_ID = x.Product_Type_ID, Price_Figure = db.Prices.Where(s => s.ProductID == x.ProductID).Select(p => p.Price_Figure).FirstOrDefault() }).ToList();
            ViewBag.ProdList = listprod;
            ProductClass model = new ProductClass();

            if (ProductId > 0)
            {

                Product prod = db.Products.FirstOrDefault(x => x.ProductID == ProductId);
                model.ProductID = prod.ProductID;
                model.ProductName = prod.ProductName;
                model.Product_Type_ID = prod.Product_Type_ID;
                model.Supplier_ID = prod.Supplier_ID;
                model.Product_Qty = prod.Product_Qty;
                model.Product_Disable = prod.Product_Disable;
                model.Price_Figure = db.Prices.Where(x => x.ProductID == ProductId).OrderByDescending(x => x.Date_Initiated).Select(x => x.Price_Figure).FirstOrDefault();
                return PartialView("ProductPartial", model);
            }
            else
            {
                return PartialView("ProdPartial", model);
            }

            

        }
        [HttpGet]
        public ActionResult Disablefunc (int ProductId)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            db.Configuration.ProxyCreationEnabled = false;
            Product prod = db.Products.FirstOrDefault(x => x.ProductID == ProductId);
            if(prod.Product_Disable== false)
            {
                prod.Product_Disable = true;

            }else
            {
                prod.Product_Disable = false;
            }
            db.SaveChanges();
            
            return RedirectToAction("SearchProduct");

        }








        // ordering controller functions



        public ActionResult SearchOrder()
        {
            DrSavvyEntities db = new DrSavvyEntities();
            List<Supplier> list = db.Suppliers.ToList();
            ViewBag.SupplierList = new SelectList(list, "Supplier_ID", "SupplierName");
            List<OrderClass> listord = db.Orders.Select(x => new OrderClass { OrderID= x.OrderID, Supplier_ID=x.Supplier_ID, PaidStatus = x.PaidStatus, OS_ID=x.OS_ID,Order_Date= x.Order_Date, SupplierName = x.Supplier.SupplierName, OS_Description= x.Order_Status.OS_Description, Order_Cost= x.Order_Cost }).ToList();
                       
            ViewBag.OrderList = listord;

            
            return View();
        }

        public ActionResult PlaceOrder()
        {
            DrSavvyEntities db = new DrSavvyEntities();
            List<Supplier> slist = db.Suppliers.ToList();
            ViewBag.SupplierList = new SelectList(slist, "Supplier_ID", "SupplierName");

            return PartialView();

        }

        public ActionResult GetProducts(int supplierId)
        {
            DrSavvyEntities db = new DrSavvyEntities();

            List<Product> stateList = db.Products.Where(x => x.Supplier_ID == supplierId && x.Product_Disable==false).ToList();

            ViewBag.ProductList = new SelectList(stateList, "ProductID", "ProductName");

            return PartialView("ProductOptionPartial");

        }
        [HttpPost]
        public ActionResult GetProduct(int ID)
        {
            DrSavvyEntities db = new DrSavvyEntities();
            db.Configuration.ProxyCreationEnabled = false;
            Product Prod = db.Products.Where(p => p.ProductID == ID).SingleOrDefault();
            var Mid = Prod.ProductID;
            var name = Prod.ProductName;
            return Json(new { ProductID =Mid, ProductName = name},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveOrder(List<int> procid, List<int> procQuantity, int supId)
        {
            bool Status = false;
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                int rows = procid.Count;
                int i = 0;
                Order ord = new Order();
                Order_Line ordline = new Order_Line();

                ord.OS_ID = 2;
                ord.Supplier_ID = supId;
                ord.PaidStatus = false;
                ord.Order_Cost = 0;
                ord.Order_Date = DateTime.Now;
                db.Orders.Add(ord);
                db.SaveChanges();
                int ordID = ord.OrderID;
                Status = true;
                decimal cos = 0;
                while (i < rows)
                {
                    int id = procid[i];
                    cos += db.Prices.Where(x => x.ProductID == id).OrderByDescending(t => t.Date_Initiated).Select(x => x.Price_Figure).FirstOrDefault() * procQuantity[i];
                    ordline.OrderID = ordID;
                    ordline.ProductID = procid[i];
                    ordline.Prod_Qty = procQuantity[i];
                    db.Order_Line.Add(ordline);
                    db.SaveChanges();
                    i++;
                }
                Order orde = db.Orders.Where(x => x.OrderID == ordID).FirstOrDefault();
                orde.Order_Cost = cos;
                db.SaveChanges();
            }
            return Json(new { Data = Status }, JsonRequestBehavior.AllowGet);
        }









        public ActionResult ReceiveOrder(int OrderID)
        {
            
            using(DrSavvyEntities db = new DrSavvyEntities())
            {

                db.Configuration.ProxyCreationEnabled = false;
                List<ReceiveOrderClass> list = db.Order_Line.Where(p => p.OrderID == OrderID).Select(p => new ReceiveOrderClass { OrderID = p.OrderID, ProductID = p.ProductID, OrderLineID = p.OrderLineID, Prod_Qty = p.Prod_Qty, ProductName = db.Products.Where(s => s.ProductID == p.ProductID).Select(x => x.ProductName).FirstOrDefault() }).ToList();
                ViewBag.Record = list;
                

            }
                                           

            return PartialView("ReceiveOrdPartial");

        }


        [HttpPost]
        public JsonResult SaveRecOrder(List<int> procid, List<int> procQuantity, int orderID, List<int> cost)
        {
            bool Status = false;
            bool back = true;
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                int rows = procid.Count;
                int i = 0;
                decimal tot = 0;
                Order lor = db.Orders.Where(x => x.OrderID == orderID).FirstOrDefault();
                while (i < rows)
                {
                    int ProdID = procid[i];
                    int qty = procQuantity[i];
                    Order_Line OrderLine = db.Order_Line.Where(x => x.ProductID == ProdID).Where(x => x.OrderID == orderID).FirstOrDefault();
                    if(procQuantity[i] < OrderLine.Prod_Qty)
                    {
                        Order or = db.Orders.Where(x => x.OrderID == orderID).FirstOrDefault();
                        or.OS_ID = 3;
                        back = false;
                    }
                    OrderLine.ReceivedQty = qty;
                    Product prod = db.Products.Where(x => x.ProductID == ProdID).FirstOrDefault();
                    prod.Product_Qty += qty;
                    Price pri = db.Prices.Where(x => x.ProductID == ProdID).OrderByDescending(t => t.Date_Initiated).FirstOrDefault();
                    tot += cost[i]*procQuantity[i];
                    if(pri.Price_Figure != cost[i])
                    {
                        Price pr = new Price();
                        pr.Price_Figure =Convert.ToDecimal( cost[i]);
                        pr.ProductID = ProdID;
                        pr.Date_Initiated = DateTime.Now;
                        db.Prices.Add(pr);
                        db.SaveChanges();

                    }
                    db.SaveChanges();
                    i++;
                }
                lor.Order_Cost = tot;
                db.SaveChanges();
                if (back==true)
                {
                    Order or = db.Orders.Where(x => x.OrderID == orderID).FirstOrDefault();
                    or.OS_ID = 1;
                    db.SaveChanges();
                }
            }
            return Json(new { Data = Status }, JsonRequestBehavior.AllowGet);
        }



        public ActionResult PayOrder(int OrderID)
        {

            using (DrSavvyEntities db = new DrSavvyEntities())
            {

                db.Configuration.ProxyCreationEnabled = false;
                ReceiveOrderClass list = db.Order_Line.Where(p => p.OrderID == OrderID).Select(p => new ReceiveOrderClass { OrderID = p.OrderID, ProductID = p.ProductID, OrderLineID = p.OrderLineID, Prod_Qty = p.Prod_Qty, ProductName = db.Products.Where(s => s.ProductID == p.ProductID).Select(x => x.ProductName).FirstOrDefault() }).FirstOrDefault();
                ViewBag.Record = OrderID;


            }


            return PartialView("PayOrdPartial");

        }
        [HttpPost]
        public ActionResult OrderPayment(int type,int amount,string Tnum,string Inum,int ord )
        {
            using( DrSavvyEntities db = new DrSavvyEntities())
            {
                bool Status = false;
                if (type == 1)
                {
                    Order_Payment pay = new Order_Payment();
                    pay.Order_Payment_Amount = amount;
                    pay.OrderID = ord;
                    pay.Order_Payment_Date = DateTime.Now;
                    pay.TransactionNumber = Tnum;
                    Status = true;
                    pay.Payment_Type_ID = 4;
                    db.Order_Payment.Add(pay);
                    db.SaveChanges();
                }
                else
                {
                    List<Payment_Type> pad = db.Payment_Type.ToList();
                    Order_Payment pay = new Order_Payment();
                    pay.Order_Payment_Amount = amount;
                    pay.OrderID = ord;
                    pay.Order_Payment_Date = DateTime.Now;
                    pay.TransactionNumber = Inum;

                    pay.Payment_Type_ID = 1;
                    pay.ReceiptNumber = Tnum;
                    Status = true;
                    
                    db.Order_Payment.Add(pay);

                    db.SaveChanges();

                }
                decimal tot = amount;
                List<Order_Payment> pri = db.Order_Payment.Where(x => x.OrderID == ord).ToList();
                foreach(var item in pri)
                {
                    tot += item.Order_Payment_Amount;
                }
                decimal com = db.Orders.Where(x => x.OrderID == ord).Select(x => x.Order_Cost).FirstOrDefault();
                if(tot >= com)
                {
                    Order payment = db.Orders.Where(x => x.OrderID == ord).FirstOrDefault();
                    payment.PaidStatus = true;
                    db.SaveChanges();
                }
                return Json(new { Data = Status }, JsonRequestBehavior.AllowGet);
            }
            
        }







        // Stock Take controller functions



        public ActionResult ReconInv()
        {
            DrSavvyEntities db = new DrSavvyEntities();
            List<Product_Type> slist = db.Product_Type.ToList();
            ViewBag.SupplierList = new SelectList(slist, "Product_Type_ID", "Product_Type_Description");
            return View();
        }

        [HttpPost]
        public JsonResult GetList(int supplierId)
        {
            
            
            
            //List<Product> stateList = new List<Product>();
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
              var  ID = db.Products.Where(x => x.Product_Type_ID == supplierId && x.Product_Disable == false).Select(x=>x.ProductID).ToList();
                var name = db.Products.Where(x => x.Product_Type_ID == supplierId && x.Product_Disable == false).Select(x => x.ProductName).ToList();

                return Json(new { ProductID = ID, ProductName = name }, JsonRequestBehavior.AllowGet);

            }             

            

        }
        [HttpPost]
         public JsonResult CompareInv(List<int> id, List<int> procQuantity)
        {
            using (DrSavvyEntities db = new DrSavvyEntities())
            {
                string name;
                int amount;
                List<int> RecID = new List<int>();
                List<string> prod = new List<string>();
                int row = id.Count;
                int i = 0;
                bool consist = false;
                while (i < row)
                {
                    int Qty = Convert.ToInt32( db.Products.Where(x => x.ProductID == id[i]).Select(x => x.Product_Qty).FirstOrDefault());
                    if(procQuantity[i]== Qty)
                    {

                    }
                    else if(procQuantity[i] > Qty)
                    {
                        amount = procQuantity[i] - Qty;
                        name = db.Products.Where(x => x.ProductID == id[i]).Select(x => x.ProductName).FirstOrDefault();
                        prod.Add ("The " + name + " has a surplus of "+Convert.ToString(amount)+" units. Please state reason.");
                        RecID.Add( id[i]);
                        consist = true;
                    }
                    else
                    {
                        amount = Qty -procQuantity[i] ;
                        name = db.Products.Where(x => x.ProductID == id[i]).Select(x => x.ProductName).FirstOrDefault();
                        prod.Add("The " + name + " has a deficit of " + Convert.ToString(amount) + " units. Please state reason.");
                        RecID.Add(id[i]);

                        consist = true;
                    }
                    i++;
                }
                return Json(new { issues = consist, ID = RecID, Sentence =prod  }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}