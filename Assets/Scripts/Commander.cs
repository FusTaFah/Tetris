using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour {

    List<GameObject> tetriminoPiecesInControl;
    float m_timer;
    public float m_fallDelay;
    public float FallDelay { get { return m_fallDelay; } set { m_fallDelay = value; } }
    float m_angleOfRotation;

    // Use this for initialization
    void Start () {
        tetriminoPiecesInControl = new List<GameObject>();
        m_angleOfRotation = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(tetriminoPiecesInControl.Count == 0)
        {
            Debug.Log("get pieces");
            SignalDeployed();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AttemptRotation();
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
                piece.transform.position += movementDirection;
            }
        }

    }

    public void SignalDeployed()
    {
        m_angleOfRotation = 0.0f;
        tetriminoPiecesInControl = new List<GameObject>(GameObject.FindGameObjectsWithTag("TetriminoPiece"));
        tetriminoPiecesInControl.RemoveAll(x => !x.GetComponent<Controls>().InPlay);
    }

    void UpdateAllPlayableTetriminos()
    {
        bool verifiedForMovement = true;
        
        foreach (GameObject g in tetriminoPiecesInControl)
        {
            if (g.GetComponent<Controls>().checkBounds(new Vector3(0.0f, -1.0f, 0.0f)))
            {
                verifiedForMovement = false;
                break;
            }
        }
            
        if (!verifiedForMovement)
        {
            foreach (GameObject g in tetriminoPiecesInControl)
            {
                 g.GetComponent<Controls>().InPlay = false;
            }
            GameObject.Find("TetriminoFactory").GetComponent<TetriminoCreator>().TetriminoDeployed();
            GameObject.Find("TetriminoVerifier").GetComponent<TetriminoVerifier>().SignalTetriminoVerifier();
            SignalDeployed();

        }
        else
        {
            foreach (GameObject g in tetriminoPiecesInControl)
            {
                g.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
            }
        }

    }

    void AttemptRotation()
    {
        bool verifiedForRotation = true;
        foreach (GameObject tetriminoPiece in tetriminoPiecesInControl)
        {
            Vector3 tetPiPos = tetriminoPiece.transform.position;
            Vector3 tetPiLocPos = tetriminoPiece.GetComponent<Controls>().LocalTransform;
            tetriminoPiece.GetComponent<Controls>().StoredLocalTransform = new Vector3(
                    tetPiLocPos.x * Mathf.Cos(m_angleOfRotation + Mathf.PI / 2.0f) - tetPiLocPos.y * Mathf.Sin(Mathf.PI / 2.0f),
                    tetPiLocPos.x * Mathf.Sin(m_angleOfRotation + Mathf.PI / 2.0f) + tetPiLocPos.y * Mathf.Cos(Mathf.PI / 2.0f),
                    0.0f);
            Vector3 targetPosition =
                (tetPiPos - tetPiLocPos) +
                tetriminoPiece.GetComponent<Controls>().StoredLocalTransform;

            foreach(Collider collider in Physics.OverlapBox(targetPosition, new Vector3(0.25f, 0.25f, 0.25f))){
                //let's assume for now that we cant do the rotation
                verifiedForRotation = false;
                if (collider.gameObject.tag == "TetriminoPiece")
                {
                    //but if the collider belongs to a tetrimino...
                    if (collider.gameObject.GetComponent<Controls>().InPlay)
                    {
                        //...and if said tetrimino is in play, go ahead and verify this part of the check
                        verifiedForRotation = true;
                    }
                }
                else
                {
                    //otherwise break out of all the checks; we cannot rotate to this point
                    verifiedForRotation = false;
                }
                if (!verifiedForRotation)
                {
                    break;
                }
            }
                
            if(verifiedForRotation)
            {
                tetriminoPiece.GetComponent<Controls>().StoredTransform = targetPosition;
            }else
            {
                break;
            }
        }
        if (verifiedForRotation)
        {
            foreach (GameObject tetriminoPiece in tetriminoPiecesInControl)
            {
                tetriminoPiece.transform.position = tetriminoPiece.GetComponent<Controls>().StoredTransform;
                tetriminoPiece.GetComponent<Controls>().LocalTransform = tetriminoPiece.GetComponent<Controls>().StoredLocalTransform;
            }
        }
    }
}
