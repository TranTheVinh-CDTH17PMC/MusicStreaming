using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Entitis
{
    public partial class Type
    {
        public int Id { get; set; }
        public string NameType { get; set; }
        public bool? IsDelete { get; set; }
    }
}
