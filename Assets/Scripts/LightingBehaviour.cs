using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBehaviour : MonoBehaviour {
    Light m_worldLight;
    public float rotationSpeed;
	// Use this for initialization
	void Start () {
        m_worldLight = GameObject.Find("Point Light").GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.rotation.eulerAngles.x >= 360.0f)
        {
            gameObject.transform.rotation = Quaternion.identity;
        }
        else if(gameObject.transform.rotation.eulerAngles.x >= 180.0f)
        {
            m_worldLight.range = 10.0f;
        }else
        {
            m_worldLight.range = 0.0f;
        }
        gameObject.transform.RotateAround(gameObject.transform.position, new Vector3(1.0f, 0.0f, 0.0f), rotationSpeed * Time.deltaTime);
	}
}
