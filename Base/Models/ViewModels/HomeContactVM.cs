using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
	public class HomeContactVM
	{
		[Required]
		[MaxLength(100)]
		public string FirstName { get; set; } = string.Empty;
		
		[Required]
		[MaxLength(100)]
		public string LastName { get; set; } = string.Empty;
		
		[Required]
		[EmailAddress]
		public string EmailAddress { get; set; } = string.Empty;
		
		[Required]
		[Phone]
		public string PhoneNumber { get; set; } = string.Empty;
		
		[Required]
		[MaxLength(100)]
		public string CompanyName { get; set; } = string.Empty;
		
		[Required]
		[MaxLength(400)]
		public string Description { get; set; } = string.Empty;
	}
}