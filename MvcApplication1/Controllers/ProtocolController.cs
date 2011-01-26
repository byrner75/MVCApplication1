using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MvcApplication1.Models;
using Gateway.Data.Entities;

namespace MvcApplication1.Controllers
{
    public class ProtocolController : Controller
    {
        //
        // GET: /Protocol/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List(int page, int rows, string sidx, string sord, string filter)
        {           
            JavaScriptSerializer js = new JavaScriptSerializer();
            object o;
            if (Request.QueryString.AllKeys.Contains("filters"))
                o = js.DeserializeObject(Request.QueryString["filters"]);

            int records = 0;
            var rowData = MaintenanceDao.GetBranchGatewayProtocol(page, rows, ref records, sidx, sord);
            var json = new
            {
                page = page,
                total = Math.Ceiling((double) records / rows),
                records = records,
                rows =
                (
                    from iter in rowData
                    select new {
                         id = iter.id,
                         cell = new string[]                          
                         {
                             iter.id.ToString(),
                             iter.ClientApplicationName.TrimEnd(),
                             iter.GatewayId.TrimEnd(),
                             iter.FinancialInstitution,
                             iter.SourceType,iter.Branch,
                             iter.SubOffice,
                             iter.Protocol 
                         }                    
                    }
                ).ToArray()

            };

            return (Json(json, JsonRequestBehavior.AllowGet));
        }

        //
        // GET: /Protocol/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Protocol/Create

        public ActionResult Create()
        {
            return View("Edit", new BranchGatewayProtocol { id = 0 });
        } 

        //
        // POST: /Protocol/Create

        [HttpPost]
        public ActionResult Create(BranchGatewayProtocol collection)
        {
            try
            {
                if (ViewData.ModelState.IsValid == false)                
                    ViewData.ModelState.AddModelError("", "Review Form");
                else
                {
                    MaintenanceDao.SaveBranchGatewayProtocol(collection);
                    ViewData.ModelState.Clear();
                    return View("Edit", new BranchGatewayProtocol { id = 0 });                    
                }
                return View("Edit");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Protocol/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(MaintenanceDao.GetBranchGatewayProtocol().WithId(id));
        }

        public ActionResult ASPEdit(int id)
        {
            return View(MaintenanceDao.GetBranchGatewayProtocol().WithId(id));
        }

        //
        // POST: /Protocol/Edit/5

        [HttpPost]
        public ActionResult Edit(BranchGatewayProtocol collection)
        {
            try
            {
                if (ViewData.ModelState.IsValid == false)
                    ViewData.ModelState.AddModelError("", "Review Form");
                else
                {
                    MaintenanceDao.SaveBranchGatewayProtocol(collection);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult ASPEdit(BranchGatewayProtocol collection)
        {
            try
            {
                if (ViewData.ModelState.IsValid == false)
                    ViewData.ModelState.AddModelError("", "Review Form");
                else
                {
                    MaintenanceDao.SaveBranchGatewayProtocol(collection);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Protocol/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Protocol/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
