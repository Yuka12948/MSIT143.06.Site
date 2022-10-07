using System;
using System.Collections.Generic;

#nullable disable

namespace Msit14306Site.Models
{
    public partial class 導演總表director
    {
        public int 導演編號directorId { get; set; }
        public string 中文名字nameCht { get; set; }
        public string 英文名字nameEng { get; set; }
        public byte[] 導演照片image { get; set; }
    }
}
