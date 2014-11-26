using Assets.src.Gameplay.Board.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.src.Gameplay.Board
{
	[System.Serializable]
	public class MapTile 
    {

		public List<MapTile> Neighbors;
		public List<TilePath> Paths;
		public List<LandPart> LandParts;
        public List<Border> Borders;
        
		public int GlobalX;
		public int GlobalY;
        public string Id {
            get { return GlobalX + ":" + GlobalY; }
            private set {  }
        }

        public MapTile() {
            Neighbors = new List<MapTile>();
            Paths = new List<TilePath>();
            LandParts = new List<LandPart>();
            Borders = new List<Border>();
        }


        public void SetAsNeighbor(MapTile tile)
        {
            if (!this.Neighbors.Contains(tile)) {
                Neighbors.Add(tile);
            }
        }

        public void SetBorder(MapTile borderTile)
        {
            Border b = new Border(this, borderTile);
            if (!AlreadyContainsBorder(b)) {
                Borders.Add(b);
                if (!borderTile.AlreadyContainsBorder(b)) {
                    borderTile.Borders.Add(b);
                }
            }
            
        }

        private bool AlreadyContainsBorder(Border b)
        {
            foreach (Border border in Borders) {
                if (b.Id == border.Id) return true;
            }
            return false;
        }
    }
}
