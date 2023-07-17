using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Net.Security;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(30)]
        public string UserName { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }

        public int LevelID { get; set; }
        [MaxLength(50)]
        public string UserImgAddress { get; set; }


        [ForeignKey("LevelID")]
        [InverseProperty("Users")]
        public UserLevel UserLevel  { get; set; }
    }
}
