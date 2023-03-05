using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Tonk
{
	
	public class Player : MonoBehaviour
	{
		public MapManager map;
		Vector2 position;
		Tile currentTile;
		int id;
		//public Material[] materials;
		public Color[] colors;
		public MeshRenderer[] renderers;
		
		public void Reset()
		{
			map = GameObject.FindAnyObjectByType<MapManager>();
		}
		
		void Start()
		{
			if(map == null)
				map = GameObject.FindAnyObjectByType<MapManager>();
			
			position = Vector2.zero;
			
			SetTileFromPosition();
		}
		
		public void SetPlayerId(int _id)
		{
			id = _id;
			
			for(int i = 0; i < renderers.Length; i++)
			{
				renderers[i].material.color = colors[id%colors.Length];
			}
		}
		
		void SetTileFromPosition()
		{
			if(currentTile != null)
				currentTile.RemovePlayer(this);
			
			Debug.Log(position);
			currentTile = map.GetTile(position);
				
			Debug.Log(currentTile.isSwampTop);
			Debug.Log(currentTile.isBias);
			if(currentTile.isSwampTop || currentTile.teleport)
			{
				position = currentTile.teleport.position;
				
				currentTile = map.GetTile(position);
			}
				
			currentTile.AddPlayer(this);
		}
	    
		public void Move(int distance)
		{
			if(currentTile.isBias)
			{
				if(position.y >= distance)
					position.y -= distance;
				else
				{
					position.y = 0;
					distance -= (int)position.y+1;
					position.x += distance;
				}
			}else
				position.x += distance;
			
			SetTileFromPosition();
		}
	}
}