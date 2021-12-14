using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeetTalk.Data.Base
{
    public class BaseEntities
    {
        protected BaseEntities()
        {
            Guid = Guid.NewGuid();
            IsDeleted = false;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public Guid Guid { get; set; }

        public bool IsDeleted { get; set; }
    }
}