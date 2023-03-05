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
			map.SetUp();
			
		}
	    // Start is called before the first frame update
	    void Start()
	    {
	        
	    }
	
	    // Update is called once per frame
	    void Update()
	    {
	        
	    }
	}

}