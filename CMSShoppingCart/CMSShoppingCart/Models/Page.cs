using System.ComponentModel.DataAnnotations;

namespace CMSShoppingCart.Models
{
    public class Page
    {
        /// <summary>
        /// Unique page identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the page
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Url friendly representation of a title
        /// </summary>
        [Required]
        public string Slug { get; set; }

        /// <summary>
        /// Page content
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// Sorting
        /// </summary>
        public int Sorting { get; set; }
    }
}
