using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LocalList.Data.Model
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class ProjectTag
    {
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("Tag")]
        public int TagId { get; set; }

        public Project Project { get; set; }
        public Tag Tag { get; set; }
    }
}
