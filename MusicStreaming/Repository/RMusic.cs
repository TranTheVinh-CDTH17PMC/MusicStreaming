using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicStreaming.Entitis;
using MusicStreaming.Interface;

namespace MusicStreaming.Repository
{
    public class RMusic: RRepository<Music>, IMusic
    {
    }
}
