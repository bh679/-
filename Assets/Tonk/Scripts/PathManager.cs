using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BrennanHatton.Tonk
{
	/// <summary>
	/// A UnityEvent with a int as the parameter
	/// </summary>
	[System.Serializable]
	public class PlayerEvent : UnityEvent<Player> { }
    

	public class PathManager : MonoBehaviour
	{
		public MapManager map;
		public Player playerPrefab;
		public List<Player> players;
		public int playersTurn = 0;
		
		public UnityEvent onEndTurn;
		
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
		
		void Start()
		{
			AddPlayer();
			
			playersTurn = 0;
				
			onEndTurn.Invoke();
		}
		
		public void MoveNextPlayer(int pos)
		{
			Debug.Log("MoveNextPlayer " + pos);
			MovePlayer(playersTurn, pos);
			
			playersTurn++;
			if(playersTurn >= players.Count)
				playersTurn = 0;
				
			onEndTurn.Invoke();
		}
		
		public void MovePlayer(int playerId, int pos)
		{
			Debug.Log(playerId + " " + pos);
			players[playerId].Move(pos);
		}
		
		public void AddPlayer()
		{
			Player newPlayer = Instantiate(playerPrefab, this.transform) as Player;
			newPlayer.SetPlayerId(players.Count);
			players.Add(newPlayer);	
		}
		
		public void RemovePlayer()
		{
			RemovePlayer(players.Count -1);
		}
		
		public void RemovePlayer(int id)
		{
			RemovePlayer(players[id]);
		}
		
		public void RemovePlayer(Player player)
		{
			players.Remove(player);
			DestroyImmediate(player);
		}
	}

}