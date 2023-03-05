using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.Tonk
{

	public class BiasTips : MonoBehaviour
	{
		public PathManager gameManager;
		
		public TextAsset smallBiasTxt, mediumBiasTxt, largeBiasTxt, extraLargeBiasTxt;
		[HideInInspector]
		public string[] smallBias, mediumBias, largeBias, extraLargeBias;
		public int smallMax, mediumMax, largeMax;
		
		public TMP_Text text;
		
		void Reset()
		{
			gameManager = GameObject.FindFirstObjectByType<PathManager>();
		}
		
	    // Start is called before the first frame update
	    void Start()
		{
			smallBias = smallBiasTxt.text.Split('\n');
			mediumBias = mediumBiasTxt.text.Split('\n');
			largeBias = largeBiasTxt.text.Split('\n');
			extraLargeBias = extraLargeBiasTxt.text.Split('\n');
		}
		
		public void LandedOnTile(Tile tile)
		{
			if(tile.isSwampTop)
				Bias(tile.swamp.length);
		}
	    
		public void Bias(int length)
		{
			if(length < smallMax)
			{
				text.text = smallBias[Random.Range(0,smallBias.Length-1)];
			}
			else if(length < mediumMax)
			{
				text.text = mediumBias[Random.Range(0,mediumBias.Length-1)];
			}
			else if(length < largeMax)
			{
				text.text = largeBias[Random.Range(0,largeBias.Length-1)];
			}
			else 
			{
				text.text = extraLargeBias[Random.Range(0,extraLargeBias.Length-1)];
			}
		}
		
	}

}