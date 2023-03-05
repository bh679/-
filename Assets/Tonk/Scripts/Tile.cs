using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.Tonk
{
	
	public class Tile : MonoBehaviour
	{
		public bool isSwampTop;
		public bool isBias;
		public Tile teleport = null;
		public Vector2 position;
		public static float offset = 1.1f;
		public static float playerOffset = 0.25f;
		public List<Player> players = new List<Player>(); 
		public MapManager.Swamps swamp;
		
		public TMP_Text text;
		
		public void SetUp(Vector2 pos)
		{
			position = pos;
			
			if(pos.y > 0)
				transform.localPosition = Vector3.down * pos.y * offset;
			else
				transform.localPosition = Vector3.right * pos.x * offset;
				
			text.text = pos.x + " " + pos.y;
		}
		
		public void RemovePlayer(Player playerToRemove)
		{
			players.Remove(playerToRemove);
			
			PositionPlayers();
		}
		
		public void AddPlayer(Player newPLayer)
		{
			players.Add(newPLayer);
			
			PositionPlayers();
		}
		
		public void PositionPlayers()
		{
			Debug.Log("PositionPlayers");
			for(int i = 0; i < players.Count; i++)
			{
				players[i].transform.position = 
					this.transform.position 
					- Vector3.forward;
				
				if(isBias)
					players[i].transform.position +=
					Vector3.left*playerOffset*i;
				else
					players[i].transform.position +=
					Vector3.up*playerOffset*i;
			}
			
			
		}
		
	}
}