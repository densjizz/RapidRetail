using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.src.Gameplay.Board
{
    public class LandPart
    {
        public Vector2 LocalPosition;
		public Vector2 Propagation;
        

        public LandPart() {
            LocalPosition = new Vector2();
            Propagation = new Vector2();
        }
    }
}
