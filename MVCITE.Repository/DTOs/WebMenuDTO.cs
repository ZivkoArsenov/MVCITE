using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCITE.Repository.DTOs
{
    public class WebMenuDTO
    {
        public int ID { get; set; }
        public string Menu { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public int MenuTypeID { get; set; }
        public string Description { get; set; }
        public int? ParentID { get; set; }
    }
}
