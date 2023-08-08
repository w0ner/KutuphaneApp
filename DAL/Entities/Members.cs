using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Members")]
    public class Members
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Üye Adı")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(20)"), StringLength(20), Display(Name = "Üye Soyadı")]
        public string Surname { get; set; }

        [Column(TypeName = "varchar(30)"), StringLength(30), Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string Username { get; set; }

        [Column(TypeName = "varchar(32)"), StringLength(32), Display(Name = "Şifre"), Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Password { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
