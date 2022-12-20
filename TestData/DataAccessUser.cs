using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestData
{
    public class DataAccessUser
    {
        [Key]
        public int ID { get; set; }
        public int? IDSecurityUser { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        public Guid GUID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        [StringLength(150)]
        public string EmailAddress { get; set; }
    }
}
