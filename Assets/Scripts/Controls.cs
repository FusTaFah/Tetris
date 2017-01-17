using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    bool m_inPlay;

	// Use this for initialization
	void Start () {
        m_inPlay = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_inPlay)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //move left
                if(!checkBounds(new Vector3(-1.0f, 0.0f, 0.0f)))
                {
                    gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f);
                }
                
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //move right
                if (!checkBounds(new Vector3(1.0f, 0.0f, 0.0f)))
                {
                    gameObject.transform.position += new Vector3(1.0f, 0.0f, 0.0f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                //move up
                if (!checkBounds(new Vector3(0.0f, 1.0f, 0.0f)))
                {
                    gameObject.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                //move down
                if (!checkBounds(new Vector3(0.0f, -1.0f, 0.0f)))
                {
                    gameObject.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
                }
            }
        }
	}

    bool checkBounds(Vector3 direction)
    {
        Ray assumedObstacleDirection = new Ray(gameObject.transform.position, direction);
        if(Physics.Raycast(assumedObstacleDirection, 1.0f))
        {
            return true;
        }
        return false;
    }
}
