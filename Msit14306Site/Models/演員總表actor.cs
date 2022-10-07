using System;
using System.Collections.Generic;

#nullable disable

namespace Msit14306Site.Models
{
    public partial class 演員總表actor
    {
        public int 演員編號actorsId { get; set; }
        public string 中文名字nameCht { get; set; }
        public string 英文名字nameEng { get; set; }
        public byte[] 演員照片image { get; set; }
    }
}
