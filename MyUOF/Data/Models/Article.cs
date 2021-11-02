using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUOF.Data.Models
{
    //[Table("Makale")]
  public  class Article:ModelBase
    {
        public Article()
        {

        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        //[Display(Name ="hede_date")]
        //public override DateTime CreatedDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }




        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
