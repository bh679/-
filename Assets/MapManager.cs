using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
			tiles[i] = Instantiate(tilePrefab,this.transform) as Tile;
			t++;
			
			//set position
			tiles[i].transform.position = Vector3.right * i;
			
			
			int isSwamp = IsSwamp(i);
			if(isSwamp >= 0)
			{
				tiles[i].swamp = true; 
				
				swamps[isSwamp].SetUp(tilePrefab);
				
				t += swamps[isSwamp].length;
			}
		}
		
		/*
		
		for(int i = 0; i < length; i++)
		{
			
		int isTeleport = IsTeleport();
		if(isTeleport >= 0)
		{
		tiles[i].teleport = isTeleport; 
		}
		}
		
		*/
		
	}
	
	int IsSwamp(int id)
	{
		for(int i = 0; i < swamps.Length; i++)
		{
			if(swamps[i].id == id)
				return id;
		}
		
		return -1;
	}
	
	int IsTeleport(int id)
	{
		for(int i = 0; i < teleports.Length; i++)
		{
			if(teleports[i].id == id)
				return id;
		}
		
		return -1;
	}
	

	[System.Serializable]
	public class Swamps
	{
		public int id;
		public int length;
		public Teleports[] teleports;
	
		public Tile[] tiles;
	
		public void SetUp(Tile tilePrefab)
		{
			tiles = new Tile[length];
		
			for(int i = 0; i < length; i++)
			{
				tiles[i] = Instantiate(tilePrefab) as Tile;;
				
				//set position
				tiles[i].transform.position = Vector3.down * i;
			}
		}
	}

	[System.Serializable]
	public class Teleports
	{
		public int id;
		public Vector2 target;
	}
}