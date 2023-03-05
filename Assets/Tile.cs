using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BrennanHatton.Tonk
{
	
	public class Tile : MonoBehaviour
	{
		public bool isSwampTop;
		public bool isBias;
		public Tile teleport = null;
		public Vector2 position;
		public static float offset = 1.1f;
		
		public Text text;
		
		public void SetUp(Vector2 pos)
		{
			position = pos;
			//set position
			transform.localPosition = Vector3.right * pos.x * offset + Vector3.down*pos.y*offset;
		}
		
	}
}