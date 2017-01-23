using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoVerifier : MonoBehaviour {

    Vector3 m_startingPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SignalTetriminoVerifier()
    {
        //do a massive amount of computation for no fucking reason
        for(int i = 0; i < 13; i++)
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
            if(lineScore > 9)
            {
                foreach(RaycastHit hit in hits)
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
