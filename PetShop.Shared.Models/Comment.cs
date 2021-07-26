using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Shared.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        [Display(Name ="Content")]
        [Required(AllowEmptyStrings =false,ErrorMessage = "The comment must have content")]
        [StringLength(300,ErrorMessage ="The content cant be more than 300 chars.")]
        [DataType(DataType.MultilineText)]
        public string CommentInfo { get; set; }
        [Display(Name ="Name")]
        [Required(ErrorMessage ="You must enter your name !")]
        [StringLength(30,ErrorMessage ="Max length of name : 30")]
        public string WriterName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}