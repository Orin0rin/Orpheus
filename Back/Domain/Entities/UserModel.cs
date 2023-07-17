using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserModel
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
    }
}
