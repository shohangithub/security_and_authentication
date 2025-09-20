using System.ComponentModel.DataAnnotations;

public class RoleDTO
{
    [Required(ErrorMessage = "Role is required")]
    public string RoleName{ get; set; }

}