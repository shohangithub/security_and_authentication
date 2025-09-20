using System.ComponentModel.DataAnnotations;

public class AssignRoleDTO
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

     [Required(ErrorMessage = "Role is required")]
    public string Role{ get; set; }

}