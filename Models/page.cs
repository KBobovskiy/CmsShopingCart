using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmsShopingCart.Models
{
    public class Page
    {
        public int Id { get; set; }

        [Required, MinLength(length: 2, ErrorMessage = "Minimum length is 2!")]
        [Display(Name = "Page title")]
        public string Title { get; set; }

        public string Slug { get; set; }

        [Required, MinLength(length: 4, ErrorMessage = "Minimum length is 4!")]
        public string Content { get; set; }

        public int Sorting { get; set; }
    }
}