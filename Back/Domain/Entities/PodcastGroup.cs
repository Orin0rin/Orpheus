using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PodcastGroup
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int NumberOfEpisodes { get; set; }

        public bool Status { get; set; }

        [MaxLength(100)]
        public string ImgAddress { get; set; }

        public virtual ICollection<Podcast> Podcasts { get; set; }

    }
}
