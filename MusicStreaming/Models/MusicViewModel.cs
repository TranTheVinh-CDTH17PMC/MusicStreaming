using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Models
{
    public partial class MusicViewModel
    {
        public int Id { get; set; }
        public string NameMusic { get; set; }
        public string ImgInfo { get; set; }
        public string CreateDate { get; set; }
        public int? IdSinger { get; set; }
        public int? IdType { get; set; }
        public string LinkFile { get; set; }
        public bool? IsDelete { get; set; }
        public string NameSinger { get; set; }
        public string NameType { get; set; }
    }
}
