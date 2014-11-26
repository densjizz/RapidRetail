using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.src.Gameplay.Board
{
	[System.Serializable]
    public class TilePath
    {
        public INagivatable Start;
        public INagivatable End;
    }
}
