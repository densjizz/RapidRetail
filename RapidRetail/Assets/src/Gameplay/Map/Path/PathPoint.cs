using UnityEngine;
using System.Collections;





namespace Assets.src.Gameplay.Board{


	public class PathPoint {

        public const int LandType = 1;
        public const int BorderType = 2;

        public int Type;
        public Vector2 Entry;
        
        

        public PathPoint(int type, Vector2 entry)
        {
            Type = type;
            Entry = entry;
        }

        
	}
}

