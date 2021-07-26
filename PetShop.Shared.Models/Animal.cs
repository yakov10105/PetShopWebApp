using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Shared.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "You must enter name !")]
        [StringLength(30,ErrorMessage = "Name cant be longer than 30 !")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "You must enter age !")]
        [Range(0, 200,ErrorMessage ="Age must be between 0-200 !")]
        [Display(Name = "Animal Age")]
        [DataType("Int32", ErrorMessage = "Age must be a natural number.")]
        public int Age { get; set; }
        [NotMapped]
        [Display(Name ="Image File")]
        public IFormFile PictureFile{ get; set; }

        [Display(Name ="Image URL")]
        public string PictureName { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "You must enter description !")]
        [MaxLength(3000, ErrorMessage = "Description can't be longer then 3000 characters.")]
        public string Description { get; set; }

        [ForeignKey("Category")]
        [Display(Name ="Category")]
        [Required(ErrorMessage ="You must choose category !")]
        [Range(1,int.MaxValue)]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
