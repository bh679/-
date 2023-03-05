using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.Tonk
{

	public class TonkDice : MonoBehaviour
	{
		public Dice dice;
		public PathManager tonkManager;
		public Image[] images;
		
		public void Reset()
		{
			dice = this.GetComponent<Dice>();
			tonkManager = GameObject.FindObjectOfType<PathManager>();
		}
		
	    // Start is called before the first frame update
	    void Start()
	    {
		    dice.onLand.AddListener(tonkManager.MoveNextPlayer);
		    tonkManager.onEndTurn.AddListener(ChangeDiceColor);
	    }
	    
		public void ChangeDiceColor()
		{
			Debug.LogError("ChangeDiceColor " + tonkManager.playersTurn);
			for(int i = 0; i < images.Length; i++)
			{
				images[i].color = tonkManager.players[tonkManager.playersTurn].colors[tonkManager.playersTurn%tonkManager.players[0].colors.Length];
			}
		}

	}
}