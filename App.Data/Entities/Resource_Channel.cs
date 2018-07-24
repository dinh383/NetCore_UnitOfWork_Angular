namespace App.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("[Resource.Channel]")]
    public partial class Resource_Channel
    {
        [Key]
        public int ChannelId { get; set; }
        [StringLength(200)]
        public string ChannelYouTubeId { get; set; }
        [Required]
        [StringLength(200)]
        public string ChannelName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool Stop { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(30)]
        public string CreateByUser { get; set; }

        public DateTime? UpdtDate { get; set; }

        [StringLength(30)]
        public string UpdtByUser { get; set; }
    }
}
