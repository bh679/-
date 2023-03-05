﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrennanHatton.Tonk
{

	public class PathManager : MonoBehaviour
	{
		public MapManager map;
		
		public List<Player> players;
		
		public void Reset()
		{
			map = this.GetComponent<MapManager>();
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