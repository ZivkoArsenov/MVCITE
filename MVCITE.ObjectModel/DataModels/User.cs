using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MVCITE.ObjectModel.DataModels;

public partial class User
{
    [Key]
    public int ID { get; set; }

    public int? RoleID { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    public string Username { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("RoleID")]
    [InverseProperty("User")]
    public virtual Role Role { get; set; }
}
