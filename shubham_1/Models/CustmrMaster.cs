using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shubham_1.Models
{
    public class CustmrMaster
    {

        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }
       
        [Required]
        public string Gender { get; set; }
   
       
 
    }
}