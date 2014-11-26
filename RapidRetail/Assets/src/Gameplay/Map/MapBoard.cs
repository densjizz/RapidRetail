using UnityEngine;
using System.Collections;
using Assets.src.Gameplay.Board;
using System.Collections.Generic;

public class MapBoard : Object {


    public Dictionary<int, Dictionary<int, MapTile>> Tiles { get; set; }
    public List<Vector2> AvailableLocations { get { return GetAvailableLocations(); }  }


    public MapBoard() {
		Tiles = new Dictionary<int, Dictionary<int, MapTile>>();
        AddCenterBoardTile();
    }

    public bool AddTileAt(MapTile tile)
    {
		if (IsLocationAvailable(tile.GlobalX, tile.GlobalY)) {
			AddTile(tile);
            return true;
        }
        return false;
    }

	private void AddTile(MapTile tile){
        if (Tiles.ContainsKey(tile.GlobalX) && Tiles[tile.GlobalX].ContainsKey(tile.GlobalY))
        {
            ReplaceTile(tile);
        }
        else {
            InsertNewTile(tile);
        }
		
	}

    private void ReplaceTile(MapTile tile)
    {
        Tiles[tile.GlobalX][tile.GlobalY] = tile;
    }

    private void InsertNewTile(MapTile tile)
    {
        if (!Tiles.ContainsKey(tile.GlobalX)) Tiles.Add(tile.GlobalX, new Dictionary<int, MapTile>());
        if (!Tiles[tile.GlobalX].ContainsKey(tile.GlobalY)) Tiles[tile.GlobalX].Add(tile.GlobalY, tile);
        ResolvePathing(tile);
    }

    private void ResolvePathing(MapTile tile)
    {
        tile.Neighbors = GetNeighbors(tile);
        UpdateBordersWithNeighbors(tile);
    }

    private void UpdateBordersWithNeighbors(MapTile tile)
    {
        foreach (MapTile n in tile.Neighbors) {
            n.SetAsNeighbor(tile);
            tile.SetBorder(n);
        }
    }


    private List<MapTile> GetNeighbors(MapTile tile)
    {
        List<MapTile> result = new List<MapTile>();
        if (IsTilePresentAt(tile.GlobalX, tile.GlobalY))
        {
            MapTile tileOver = GetTileOver(tile);
            if (tileOver != null) result.Add(tileOver);

            MapTile tileUnder = GetTileUnder(tile);
            if (tileUnder != null) result.Add(tileUnder);

            MapTile tileLeft = GetTileLeft(tile);
            if (tileLeft != null) result.Add(tileLeft);

            MapTile tileRight = GetTileRight(tile);
            if (tileRight != null) result.Add(tileRight);
        }
        return result;
    }

    private MapTile GetTileOver(MapTile tile)
    {
        bool tileExists = IsTilePresentAt(tile.GlobalX, tile.GlobalY - 1);
        if (tileExists) return Tiles[tile.GlobalX][tile.GlobalY-1];
        return null;
    }

    private MapTile GetTileUnder(MapTile tile)
    {
        bool tileExists = IsTilePresentAt(tile.GlobalX, tile.GlobalY + 1);
        if (tileExists) return Tiles[tile.GlobalX][tile.GlobalY+1];
        return null;
    }

    private MapTile GetTileLeft(MapTile tile)
    {
        bool tileExists = IsTilePresentAt(tile.GlobalX - 1, tile.GlobalY);
        if (tileExists) return Tiles[tile.GlobalX - 1][tile.GlobalY];
        return null;
    }

    private MapTile GetTileRight(MapTile tile)
    {
        bool tileExists = IsTilePresentAt(tile.GlobalX + 1, tile.GlobalY);
        if (tileExists) return Tiles[tile.GlobalX+1][tile.GlobalY];
        return null;
    }

    public bool IsTilePresentAt(int x, int y)
    {
        bool PresentInTiles = (Tiles.ContainsKey(x) && Tiles[x].ContainsKey(y));
        return ( PresentInTiles && (Tiles[x][y] != null) );
    }

    private bool IsLocationAvailable(int x, int y)
    {
        bool PresentInMap = Tiles.ContainsKey(x) && Tiles[x].ContainsKey(y);

        return !PresentInMap || (Tiles[x][y] == null);
    }

    private List<Vector2> GetAvailableLocations()
    {
        List<Vector2> result = new List<Vector2>();
        return null; 
    }

    private void AddCenterBoardTile(){
		MapTile centerTopLeft = new MapTile(){GlobalX = 0, GlobalY = 0};
		MapTile centerTopRight = new MapTile(){GlobalX = 1, GlobalY = 0};
		MapTile centerBottomLeft = new MapTile(){GlobalX = 0, GlobalY = 1};
		MapTile centerBottomRight = new MapTile(){GlobalX = 1, GlobalY = 1};
		AddTile(centerTopLeft);
		AddTile(centerTopRight);
		AddTile(centerBottomLeft);
		AddTile(centerBottomRight);
    }

    public Rect GetBound() {
        int Left = GetSmallestX();
        int Right = GetBiggestX();
        int Top = GetSmallestY();
        int Bottom = GetBiggestY();

        return new Rect(Left, Top, Right - Left, Bottom - Top);
    }

    private int GetSmallestX()
    {
        int value = int.MaxValue;
        foreach (int key in Tiles.Keys)
        {
            if (key < value)
            {
                value = key;
            }
        }
        return value;
    }


    private int GetBiggestX()
    {
        int value = int.MinValue;
        foreach (int key in Tiles.Keys)
        {
            if (key > value)
            {
                value = key;
            }
        }
        return value;
    }

    private int GetSmallestY()
    {
        int value = int.MaxValue;
        foreach (int key in Tiles.Keys)
        {
            foreach(int ykey in Tiles[key].Keys){
                if (ykey < value) {
                    value = ykey;
                }
            }
        }
        return value;
    }

    private int GetBiggestY()
    {
        int value = int.MinValue;
        foreach (int key in Tiles.Keys)
        {
            foreach (int ykey in Tiles[key].Keys)
            {
                if (ykey > value)
                {
                    value = ykey;
                }
            }
        }
        return value;
    }
}
