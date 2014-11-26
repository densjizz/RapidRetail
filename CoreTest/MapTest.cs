using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.src.Gameplay.Board;
using UnityEngine;
using Assets.src.Gameplay.Board.Path;

namespace CoreTest
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void MapBoardTest()
        {

            //Arrange
            MapBoard map = new MapBoard();


            MapTile newTile = new MapTile();

            newTile.GlobalX = 2;
            newTile.GlobalY = 0;

            newTile.LandParts.Add(new LandPart() { LocalPosition = new Vector2(0, 0)} );
            newTile.LandParts.Add(new LandPart() { LocalPosition = new Vector2(1, 0) });
            newTile.LandParts.Add(new LandPart() { LocalPosition = new Vector2(0, 1) });
            newTile.LandParts.Add(new LandPart() { LocalPosition = new Vector2(1, 1) });
            

            newTile.Paths.Add(new TilePath() 
                { 
                    Start = new LandPoint(newTile.LandParts[0]),
                    End = new LandPoint(newTile.LandParts[2]),
                });
            
            //Act

            bool success = map.AddTileAt(newTile);
            
            //Assert
        }


        
    }
}
