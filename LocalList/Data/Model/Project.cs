using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalList.Data.Model
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("名称")]
        public string Name { get; set; }
        [DisplayName("标题")]
        public string Title { get; set; }
        [DisplayName("地址")]
        public string Address { get; set; }
        [DisplayName("描述")]
        public string Description { get; set; }
        [DisplayName("添加时间")]
        public DateTime AddTime { get; set; }
    }
}
