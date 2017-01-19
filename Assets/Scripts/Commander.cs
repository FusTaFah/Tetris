using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour {

    GameObject[] tetriminoPiecesInControl;

	// Use this for initialization
	void Start () {
        tetriminoPiecesInControl = new GameObject[0];
	}
	
	// Update is called once per frame
	void Update () {
        if(tetriminoPiecesInControl.Length == 0)
        {
            Debug.Log("get pieces");
            tetriminoPiecesInControl = GameObject.FindGameObjectsWithTag("TetriminoPiece");
        }
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
        bool allClear = true;
        foreach(GameObject piece in tetriminoPiecesInControl)
        {
            if (piece.GetComponent<Controls>().checkBounds(movementDirection))
            {
                allClear = false;
                break;
            }
        }

        if (allClear)
        {
            foreach(GameObject piece in tetriminoPiecesInControl)
            {
                gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f);
            }
        }

    }
}
