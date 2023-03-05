using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A UnityEvent with a int as the parameter
/// </summary>
[System.Serializable]
public class IntEvent : UnityEvent<int> { }
    
public class Dice : MonoBehaviour
{
	public IntEvent onLand, onUpdateDisplay;
	
	public GameObject[] images;
	public int value;
	
	public Vector2 landTime = new Vector2(1f, 5f);
	
	public void Roll()
	{
		StartCoroutine(rolling());
	}
	
	IEnumerator rolling()
	{
		float time = Random.Range(landTime.x, landTime.y);
		
		while(time > 0)
		{
			yield return new WaitForSeconds(0.1f);
			
			value = Random.Range(1,6);
			UpdateDisplay(value);
			
			time -= 0.1f;
		}
		
		value = Random.Range(1,6);
		
		UpdateDisplay(value);
		
		onLand.Invoke(value);
		
		yield return null;
	}
	
	void UpdateDisplay(int val)
	{
		onUpdateDisplay.Invoke(val);
		
		for(int i = 0 ; i < images.Length; i++)
		{
			images[i].SetActive(false);
		}
		
		images[val-1].SetActive(true);
	}
}
