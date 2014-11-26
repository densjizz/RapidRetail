using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.src.Gameplay.Board.Path
{
    public class LandPoint : INagivatable
    {
        

        public LandPoint(LandPart landPart)
        {
            this.Node = new PathPoint(PathPoint.LandType , landPart.LocalPosition);
        }
    }
}
