using System.ComponentModel.DataAnnotations;

public class AddClaimRoleDTO
{
    [Required(ErrorMessage = "Role Name is required")]
    public string RoleName { get; set; }

    [Required(ErrorMessage = "Claim Name is required")]
    public string ClaimName { get; set; }
    
    [Required(ErrorMessage = "Claim Value is required")]
    public string ClaimValue{ get; set; }

}