using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    public enum PlayerState
    {
        idle = 0001,
        running = 0010,
        jumping = 0100,
        falling = 1000
    }
}
