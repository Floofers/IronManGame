using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronManGame
{
    public enum PlayerState
    {
        idle,
        running,
        jumping,
        falling,
        shooting,
        crouching,
        shootingWhileRunning,
        shootingWhileCrouching,
        doubleJumping
    }
}
