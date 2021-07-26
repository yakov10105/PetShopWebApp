using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop.Shared.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Animal must have Category")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }
        public virtual IEnumerable<Animal> Animals { get; set; }
    }
}
