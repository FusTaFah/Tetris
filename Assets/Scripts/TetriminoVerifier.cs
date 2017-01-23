using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoVerifier : MonoBehaviour {

    Vector3 m_startingPosition;

	// Use this for initialization
	void Start () {
        m_startingPosition = new Vector3(-6.0f, 10.0f, 0.0f);
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
            foreach(RaycastHit hit in hits)
            {
                if(hit.collider.gameObject.tag == "TetriminoPiece")
                {
                    lineScore++;
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
            }
            gameObject.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
        }
        gameObject.transform.position = m_startingPosition;
    }
}
