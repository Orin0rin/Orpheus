using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Podcast
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

       [DataType(DataType.Date)]
       [Column(TypeName ="Date")]
        public DateTime PublishDate { get; set; }

        public int GroupID { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string VoiceAddress { get; set; }

        [ForeignKey("GroupID")]
        [InverseProperty("Podcasts")]
        [AllowNull]
        public PodcastGroup PodcastGroup { get; set; }

    }
}
