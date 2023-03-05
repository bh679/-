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
		
		public void Reset()
		{
			map = GameObject.FindAnyObjectByType<MapManager>();
		}
		
		void Start()
		{
			position = Vector2.zero;
			
			SetTileFromPosition();
		}
		
		void SetTileFromPosition()
		{
			Debug.Log(position);
			currentTile = map.GetTile(position);
				
			Debug.Log(currentTile.isSwampTop);
			Debug.Log(currentTile.isBias);
			if(currentTile.isSwampTop || currentTile.teleport)
			{
				position = currentTile.teleport.position;
				
				currentTile = map.GetTile(position);
			}
			
			this.transform.position = currentTile.transform.position 
				- Vector3.forward;
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