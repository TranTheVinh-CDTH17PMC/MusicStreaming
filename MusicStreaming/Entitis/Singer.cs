using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Entitis
{
    public partial class Singer
    {
        public int Id { get; set; }
        public string NameSinger { get; set; }
        public string ImgInfo { get; set; }
        public bool? IsDelete { get; set; }
    }
}
