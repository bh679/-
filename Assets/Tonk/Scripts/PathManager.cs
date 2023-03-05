using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Tonk
{

	public class PathManager : MonoBehaviour
	{
		public MapManager map;
		public List<Player> players;
		public int playersTurn = 0;
		
		public void Reset()
		{
			map = this.GetComponent<MapManager>();
			map.SetUp();
			
			players = new List<Player>();
			Player[] playersFound = GameObject.FindObjectsOfType<Player>();
			
			for(int i = 0; i < playersFound.Length; i++)
			{
				players.Add(playersFound[i]);
			}
			
		}
		
		public void MoveNextPlayer(int pos)
		{
			Debug.Log("MoveNextPlayer");
			if(playersTurn >= players.Count)
				playersTurn = 0;
				
			MovePlayer(playersTurn, pos);
			
			playersTurn++;
		}
		
		public void MovePlayer(int playerId, int pos)
		{
			Debug.Log(playerId + " " + pos);
			players[playerId].Move(pos);
		}
	}

}