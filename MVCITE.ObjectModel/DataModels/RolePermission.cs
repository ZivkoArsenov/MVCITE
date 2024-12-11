using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MVCITE.ObjectModel.DataModels;

[PrimaryKey("RoleID", "PermissionID")]
public partial class RolePermission
{
    [Key]
    public int RoleID { get; set; }

    [Key]
    public int PermissionID { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("PermissionID")]
    [InverseProperty("RolePermission")]
    public virtual Permission Permission { get; set; }

    [ForeignKey("RoleID")]
    [InverseProperty("RolePermission")]
    public virtual Role Role { get; set; }
}
