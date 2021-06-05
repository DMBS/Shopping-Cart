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
        [Required, MinLength(2, ErrorMessage ="Minimum length is 2")]
        public string Title { get; set; }

        /// <summary>
        /// Url friendly representation of a title
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Page content
        /// </summary>
        [Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Content { get; set; }

        /// <summary>
        /// Sorting
        /// </summary>
        public int Sorting { get; set; }
    }
}
