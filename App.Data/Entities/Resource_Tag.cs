namespace App.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("[Resource.Tag]")]
    public partial class Resource_Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [StringLength(200)]
        public string TagName { get; set; }

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
