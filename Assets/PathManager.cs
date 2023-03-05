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
		
		/*void Start()
		{
			for(int i = 0; i < players.Count; i++)
			{
				players[i].map = map;
			}
		}*/
		
		public void MoveNextPlayer(int pos)
		{
			Debug.Log("MoveNextPlayer");
			playersTurn++;
			if(playersTurn >= players.Count)
				playersTurn = 0;
				
			MovePlayer(playersTurn, pos);
		}
		
		public void MovePlayer(int playerId, int pos)
		{
			Debug.Log(playerId + " " + pos);
			players[playerId].Move(pos);
		}
	}

}