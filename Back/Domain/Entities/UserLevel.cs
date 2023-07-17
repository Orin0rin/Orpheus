using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserLevel
    {
        [Key]
        public int ID { get; set; }
        public string Level { get; set; }
        public string Authority { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
