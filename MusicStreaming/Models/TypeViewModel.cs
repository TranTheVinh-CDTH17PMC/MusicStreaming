using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Models
{
    public partial class TypeViewModel
    {
        public int Id { get; set; }
        public string NameType { get; set; }
        public bool? IsDelete { get; set; }
    }
}
