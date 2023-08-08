using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Book")]
    public class Book
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Kitap Adı")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Kitap Yazarı")]
        public string Writer { get; set; }

        [Column(TypeName = "varchar(150)"), StringLength(150), Display(Name = "Kitap Resmi"), Required(ErrorMessage = "Kitap Resmi Boş Geçilemez")]
        public string Picture { get; set; }

        [Column(TypeName = "bit"), Display(Name = "Kitap Durumu")]
        public bool Status { get; set; }

        [Display(Name = "Alış Tarihi")]
        public DateTime BuyDate { get; set; }

        [Display(Name = "Veris Tarihi")]
        public DateTime DataDate { get; set; }

        [Display(Name = "Üye")]
        public int? MembersID { get; set; }
        public Members Members { get; set; }
    }
}
