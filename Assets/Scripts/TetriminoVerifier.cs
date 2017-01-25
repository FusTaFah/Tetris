using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TetriminoVerifier : MonoBehaviour {

    Vector3 m_startingPosition;
    List<GameObject> m_tetriminosToMoveDown;
    List<GameObject> m_previousTetriminosToMoveDown;

    // Use this for initialization
    void Start () {
        m_startingPosition = new Vector3(-6.0f, 10.0f, 0.0f);
        m_tetriminosToMoveDown = new List<GameObject>();
        m_previousTetriminosToMoveDown = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SignalTetriminoVerifier()
    {
        //do a massive amount of computation for no fucking reason
        for(int i = 0; i < 14; i++)
        {
            int lineScore = 0;
            RaycastHit[] hits = Physics.RaycastAll(new Ray(gameObject.transform.position, new Vector3(1.0f, 0.0f, 0.0f)));
            List<GameObject> potentialAdditions = new List<GameObject>();
            foreach(RaycastHit hit in hits)
            {
                if(hit.collider.gameObject.tag == "TetriminoPiece")
                {
                    lineScore++;
                    potentialAdditions.Add(hit.collider.gameObject);
                }
            }
            
            if (lineScore > 10)
            {
                foreach(GameObject tetriminoPiece in potentialAdditions)
                {
                    Destroy(tetriminoPiece);
                }
                //foreach (GameObject tetriminoPiece in m_previousTetriminosToMoveDown)
                //{
                //    tetriminoPiece.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
                //}
                foreach (GameObject tetriminoPiece in m_tetriminosToMoveDown)
                {
                    if(tetriminoPiece != null/* && !tetriminoPiece.GetComponent<Controls>().checkBounds(new Vector3(0.0f, -1.0f, 0.0f))*/)
                    {
                        tetriminoPiece.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
                    }
                }
            }
            else
            {
                m_tetriminosToMoveDown = m_tetriminosToMoveDown.Concat(potentialAdditions).ToList();
            }
            gameObject.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
            //m_previousTetriminosToMoveDown = potentialAdditions;
        }
        gameObject.transform.position = m_startingPosition;
        m_tetriminosToMoveDown.Clear();
    }
}
