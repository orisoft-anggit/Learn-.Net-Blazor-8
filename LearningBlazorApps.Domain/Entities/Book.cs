using System.ComponentModel.DataAnnotations;
using LearningBlazorApps.Domain.Enums;

namespace LearningBlazorApps.Domain.Entities
{
	public class Book
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please provide a title")]
		[StringLength(100)]
		public string? Title { get; set; }

        [Required(ErrorMessage = "Please provide the author's name")]
        [StringLength(100)]
        public string? Author { get; set; }

		public DateTime? PublicationDate { get; set; }

		[EnumDataType(typeof(Category), ErrorMessage ="Please Select a Category")]
		public Category Category { get; set; }
    }
}

