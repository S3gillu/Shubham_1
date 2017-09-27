using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shubham_1.Models;
using System.Data.Entity;

namespace shubham_1.Controllers
{
    public class CustmrController : Controller
    {
        // GET: Custmr
        public JsonResult GetStudents(string sidx, string sort, int page, int rows)
        {
          IdentityModel db = new IdentityModel();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var CustmrList = db.Custmrs.Select(
                    t => new
                    {
                        t.ID,
                        t.Name,
                        t.Gender
                    });
            int totalRecords = CustmrList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                CustmrList = CustmrList.OrderByDescending(t => t.Name);
                CustmrList = CustmrList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                CustmrList = CustmrList.OrderBy(t => t.Name);
                CustmrList = CustmrList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = CustmrList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        //Create
        
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] CustmrMaster Model)
        {
         IdentityModel db = new IdentityModel();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Model.ID = Guid.NewGuid().ToString();
                    db.Custmrs.Add(Model);
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfully";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        //Update
        public string Edit(CustmrMaster Model)
        {
   IdentityModel db = new IdentityModel();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Model).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfully";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        //Delete
        public string Delete(string Id)
        {
     IdentityModel db = new IdentityModel();
            CustmrMaster student = db.Custmrs.Find(Id);
            db.Custmrs.Remove(student);
            db.SaveChanges();
            return "Deleted successfully";
        }


    }
}