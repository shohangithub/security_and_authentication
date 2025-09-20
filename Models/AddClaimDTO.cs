using System.ComponentModel.DataAnnotations;

public class AddClaimDTO
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Claim Name is required")]
    public string ClaimName { get; set; }
    
    [Required(ErrorMessage = "Claim Value is required")]
    public string ClaimValue{ get; set; }

}