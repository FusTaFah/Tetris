using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour {

    ArrayList tetriminoPiecesInControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //move left
            attemptMovement(new Vector3(-1.0f, 0.0f, 0.0f));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //move right
            attemptMovement(new Vector3(1.0f, 0.0f, 0.0f));
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //move up
            attemptMovement(new Vector3(0.0f, 1.0f, 0.0f));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //move down
            attemptMovement(new Vector3(0.0f, -1.0f, 0.0f));
        }
    }

    void attemptMovement(Vector3 movementDirection)
    {
        foreach(GameObject piece in tetriminoPiecesInControl)
        {
            if (!piece.GetComponent<Controls>().checkBounds(movementDirection))
            {
                gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f);
            }
        }
        
    }
}
