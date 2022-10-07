using System;
using System.Collections.Generic;

#nullable disable

namespace Msit14306Site.Models
{
    public partial class 會員member
    {
        public int 會員編號memberId { get; set; }
        public string 會員電話cellphone { get; set; }
        public string 密碼password { get; set; }
        public string 姓氏lName { get; set; }
        public string 名字fName { get; set; }
        public string 暱稱nickName { get; set; }
        public DateTime? 生日birthDate { get; set; }
        public int? 性別gender { get; set; }
        public string 電子信箱email { get; set; }
        public string 地址address { get; set; }
        public int? 紅利點數bonus { get; set; }
        public bool 正式會員formal { get; set; }
        public int 會員權限permission { get; set; }
        public byte[] 會員照片image { get; set; }
        public DateTime 建立時間createdTime { get; set; }
    }
}
