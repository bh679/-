using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraRatio : MonoBehaviour
{
	public float cameraHeight = 11.36f;
	public float desiredAspect = 2f;
	
    // Start is called before the first frame update
    void Start()
    {
	    float aspect = Camera.main.aspect;
	    float ratio =  desiredAspect / aspect;
	    Camera.main.orthographicSize = cameraHeight * ratio;
	
    }

    // Update is called once per frame
    void Update()
    {
	    float aspect = Camera.main.aspect;
	    float ratio =  desiredAspect / aspect;
	    Camera.main.orthographicSize = cameraHeight * ratio;
    }
}
