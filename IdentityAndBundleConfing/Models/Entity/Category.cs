using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityAndBundleConfing.Models.Entity
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
    }
}