using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shubham_1.Models;
using System.Data.Entity;


namespace shubham_1.Models
{
    public class IdentityModel :DbContext
    {


        public IdentityModel()
                : base("Cust")
             {
             }
        public DbSet<CustmrMaster> Custmrs { get; set; }
    }



}