using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBehaviour : MonoBehaviour {
    public Light WorldLight;
    public float rotationSpeed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.rotation.eulerAngles.x >= 360.0f)
        {
            gameObject.transform.rotation = Quaternion.identity;
        }
        else if(gameObject.transform.rotation.eulerAngles.x >= 180.0f)
        {
            WorldLight.range = 10.0f;
        }else
        {
            WorldLight.range = 0.0f;
        }
        gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(1.0f, 0.0f, 0.0f), rotationSpeed * Time.deltaTime);
	}
}
