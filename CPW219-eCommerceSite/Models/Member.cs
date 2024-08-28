using System.ComponentModel.DataAnnotations;

namespace CPW219_eCommerceSite.Models
{
    /// <summary>
    /// This class creates a member object that will be stored
    /// into a database.
    /// </summary>
    public class Member
    {
        /// <summary>
        /// The Id is for the database to keep track of individual members
        /// and is hidden from the user.
        /// </summary>
        [Key]
        public int MemberId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? UserName { get; set; }

        public string? Phone { get; set; }
    }

    /// <summary>
    /// This class creates a member object when a member is succesfully
    /// created in the register view.
    /// </summary>
    [Microsoft.EntityFrameworkCore.Keyless]
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Compare(nameof(Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof (Password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// This class creates a member object when a user tries to login and this object's
    /// credentials are verified by checking if the database contains them.
    /// </summary>
    [Microsoft.EntityFrameworkCore.Keyless]
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
