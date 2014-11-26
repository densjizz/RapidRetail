using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.src.Gameplay.Board.Path
{
    public class Border
    {
        public MapTile Start;
        public MapTile End;
        public string Id;

        public Border(MapTile start, MapTile end) {
            Start = start;
            End = end;
            Id = start.Id + "-" + end.Id;
        }
    }
}
