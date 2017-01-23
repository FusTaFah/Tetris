using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour {

    GameObject[] tetriminoPiecesInControl;
    float m_timer;
    public float m_fallDelay;
    public float FallDelay { get { return m_fallDelay; } set { m_fallDelay = value; } }

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
        else if (Input.GetKeyDown(KeyCode.S))
        {
            //move down
            attemptMovement(new Vector3(0.0f, -1.0f, 0.0f));
        }

        if (m_timer >= m_fallDelay)
        {
            UpdateAllPlayableTetriminos();
            m_timer = 0.0f;
        }
        m_timer += Time.deltaTime;
    }

    void attemptMovement(Vector3 movementDirection)
    {
        bool allClear = true;
        foreach(GameObject piece in tetriminoPiecesInControl)
        {
            if (piece.GetComponent<Controls>().InPlay)
            {
                if (piece.GetComponent<Controls>().checkBounds(movementDirection))
                {
                    allClear = false;
                    break;
                }
            }
        }

        if (allClear)
        {
            foreach(GameObject piece in tetriminoPiecesInControl)
            {
                if (piece.GetComponent<Controls>().InPlay)
                {
                    piece.transform.position += movementDirection;
                }
            }
        }

    }

    public void SignalDeployed()
    {
        tetriminoPiecesInControl = new GameObject[0];
        tetriminoPiecesInControl = GameObject.FindGameObjectsWithTag("TetriminoPiece");
    }

    void UpdateAllPlayableTetriminos()
    {
        bool verifiedForMovement = true;
        
        foreach (GameObject g in tetriminoPiecesInControl)
        {
            if (g.GetComponent<Controls>().InPlay)
            {
                if (g.GetComponent<Controls>().checkBounds(new Vector3(0.0f, -1.0f, 0.0f)))
                {
                    verifiedForMovement = false;
                    break;
                }
            }
            
        }
            
        if (!verifiedForMovement)
        {
            foreach (GameObject g in tetriminoPiecesInControl)
            {
                if (g != gameObject && g.GetComponent<Controls>().InPlay)
                {
                    g.GetComponent<Controls>().InPlay = false;
                }
            }
            GameObject.Find("TetriminoFactory").GetComponent<TetriminoCreator>().TetriminoDeployed();
            SignalDeployed();
        }
        else
        {
            foreach (GameObject g in tetriminoPiecesInControl)
            {
                if (g.GetComponent<Controls>().InPlay)
                {
                    g.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
                }
            }
        }

    }
}
