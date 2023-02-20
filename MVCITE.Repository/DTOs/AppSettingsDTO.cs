using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCITE.Repository.DTOs
{
    public class AppSettingsDTO
    {
        [Key]
        public int ID { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(250)]
        public string SecurityAPIBaseEndPoint { get; set; }
        [StringLength(250)]
        public string MVCITEAPIBaseEndPoint { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string CreatedUser { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LastChangedDate { get; set; }
        [StringLength(50)]
        public string LastChangedUser { get; set; }
        public bool? IsActive { get; set; }
    }
}
