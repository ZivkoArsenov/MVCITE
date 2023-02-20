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
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Menu { get; set; }
        [StringLength(100)]
        public string Controller { get; set; }
        [StringLength(100)]
        public string Action { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int Sort { get; set; }
        public bool IsActive { get; set; }
        [StringLength(50)]
        public string CreatedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string LastChangedUser { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastChangedDate { get; set; }
        public int MenuTypeID { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public int? ParentID { get; set; }
    }
}
