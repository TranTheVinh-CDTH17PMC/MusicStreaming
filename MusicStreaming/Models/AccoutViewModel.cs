﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStreaming.Models
{
    public partial class AccoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool? IsDelete { get; set; }
    }
}
