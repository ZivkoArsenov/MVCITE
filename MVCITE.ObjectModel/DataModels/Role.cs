using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace MVCITE.ObjectModel.DataModels;

public partial class Role
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(5)]
    [Unicode(false)]
    public string Code { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public string Description { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<RolePermission> RolePermission { get; set; } = new List<RolePermission>();

    [InverseProperty("Role")]
    public virtual ICollection<User> User { get; set; } = new List<User>();
}
