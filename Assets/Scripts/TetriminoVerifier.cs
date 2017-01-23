using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoVerifier : MonoBehaviour {

    Vector3 m_startingPosition;
    List<GameObject> m_tetriminosToMoveDown;

	// Use this for initialization
	void Start () {
        m_startingPosition = new Vector3(-6.0f, 10.0f, 0.0f);
        m_tetriminosToMoveDown = new List<GameObject>();
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
            if(lineScore > 10)
            {
                foreach(RaycastHit hit in hits)
                {
                    if(hit.collider.gameObject.tag == "TetriminoPiece")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }
                foreach(GameObject tetriminoPiece in m_tetriminosToMoveDown)
                {
                    tetriminoPiece.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
                }
            }else
            {
                m_tetriminosToMoveDown.AddRange(potentialAdditions);
            }
            gameObject.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
        }
        gameObject.transform.position = m_startingPosition;
    }
}
