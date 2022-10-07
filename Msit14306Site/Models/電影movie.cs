using System;
using System.Collections.Generic;

#nullable disable

namespace Msit14306Site.Models
{
    public partial class 電影movie
    {
        public int 電影編號movieId { get; set; }
        public int? 系列編號seriesId { get; set; }
        public string 中文標題titleCht { get; set; }
        public string 英文標題titleEng { get; set; }
        public int 上映年份releaseYear { get; set; }
        public DateTime? 上映日期releaseDate { get; set; }
        public DateTime? 最後上映日期releasedDate { get; set; }
        public int 片長runtime { get; set; }
        public int 電影分級編號ratingId { get; set; }
        public decimal? 評分rate { get; set; }
        public decimal? 期待度anticipation { get; set; }
        public string 票房boxOffice { get; set; }
        public string 劇情大綱plot { get; set; }
    }
}
