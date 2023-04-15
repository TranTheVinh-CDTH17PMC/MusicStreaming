using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Entitis
{
    public partial class AccountMusic
    {
        public int Id { get; set; }
        public int? IdAccount { get; set; }
        public int? IdMusic { get; set; }
        public bool? IsDelete { get; set; }
    }
}
