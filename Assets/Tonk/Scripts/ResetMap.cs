using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Tonk
{
	public class ResetMap : MonoBehaviour
	{
		
		public void Reset()
		{
			MapManager map = this.GetComponent<MapManager>();
			
			for(int i = 0; i < map.tiles.Length; i++)
				DestroyImmediate(map.tiles[i]);
			
			map.SetUp();
			
		}
	}

}