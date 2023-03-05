using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Tonk
{
	
	public class MapManager : MonoBehaviour
	{
		public int length;
		public Swamps[] swamps;
		public Teleports[] teleports;
		public Tile tilePrefab;
		
		public Tile[] tiles;
		
		public int NumberOfTilesNeeded()
		{
			int tilesNeeded = length;
			
			for(int i = 0; i < swamps.Length; i++)
			{
				tilesNeeded += swamps[i].length;
			}
			
			return tilesNeeded;
		}
		
		public void SetUp()
		{
			tiles = new Tile[length];
			int t =  0;
			
			for(int i = 0; i < length; i++)
			{
				Debug.Log(i);
				tiles[i] = Instantiate(tilePrefab, this.transform) as Tile;
				
				tiles[i].SetUp(new Vector2(i,0));
				//tiles[i].position = ;
				
				
				int isSwamp = IsSwamp(i);
				if(isSwamp >= 0)
				{
					tiles[i].isSwampTop = true; 
					tiles[i].swamp = swamps[isSwamp];
					
					swamps[isSwamp].SetUp(tilePrefab, tiles[i]);
					
					t += swamps[isSwamp].length;
				}
			}
			
			SetUpTeleports();
		}
		
		public void SetUpTeleports()
		{	
			
			for(int i = 0; i < length; i++)
			{
				
				int teleportId = IsTeleport(i);
				if(teleportId >= 0)
				{
					tiles[i].teleport = GetTile(teleports[teleportId].target);
				}
				
				int isSwamp = IsSwamp(i);
				if(isSwamp >= 0)
				{
					swamps[isSwamp].SetUpTeleports(this);
				}
			}
			
		}
		
		int IsSwamp(int id)
		{
			for(int i = 0; i < swamps.Length; i++)
			{
				if(swamps[i].id == id)
					return i;
			}
			
			return -1;
		}
		
		int IsTeleport(int id)
		{
			for(int i = 0; i < teleports.Length; i++)
			{
				if(teleports[i].id == id)
					return i;
			}
			
			return -1;
		}
		
		/// <summary>
		/// Get tile from tile position
		/// </summary>
		/// <param name="pos"></param>
		public Tile GetTile(Vector2 pos)
		{
			Tile retTile = tiles[(int)pos.x];
			
			if(retTile.isSwampTop)
			{
				return swamps[IsSwamp((int)pos.x)].tiles[(int)pos.y];
			}
			
			return retTile;
		}
		
		
		
		
		
		
		
		
	
		[System.Serializable]
		public class Swamps
		{
			public int id;
			public int length;
			public Teleports[] teleports;
		
			public Tile[] tiles;
			public Tile parent;
		
			public void SetUp(Tile tilePrefab, Tile _parent)
			{
				parent = _parent;
				
				tiles = new Tile[length+1];
			
				tiles[0] = _parent;
				tiles[length] = _parent;
			
				for(int i = 1; i < length; i++)
				{
					tiles[i] = Instantiate(tilePrefab, parent.transform) as Tile;
					tiles[i].SetUp(
						new Vector2(parent.position.x, i)
					);
					tiles[i].isBias = true;
				}
			}
			
			
		
			public void SetUpTeleports(MapManager map)
			{	
				parent.teleport = tiles[length-1];
			
				for(int i = 0; i < length; i++)
				{
					int teleportId = IsTeleport(i);
					
					if(teleportId >= 0)
					{
						tiles[i].teleport = map.GetTile(teleports[teleportId].target);
					}
				}
			}
		
			int IsTeleport(int id)
			{
				for(int i = 0; i < teleports.Length; i++)
				{
					if(teleports[i].id == id)
						return i;
				}
			
				return -1;
			}
		}
	
		[System.Serializable]
		public class Teleports
		{
			public int id;
			public Vector2 target;
		}
	}
}