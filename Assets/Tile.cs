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
		
	}
}