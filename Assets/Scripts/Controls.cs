using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    bool m_inPlay;
    
    public bool InPlay { get { return m_inPlay; } set { m_inPlay = value; } }
    
	// Use this for initialization
	void Start () {
        m_inPlay = true;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public bool checkBounds(Vector3 direction)
    {
        Ray assumedObstacleDirection = new Ray(gameObject.transform.position, direction);
        RaycastHit raycastIdentity;
        if (Physics.Raycast(assumedObstacleDirection, out raycastIdentity, 1.0f))
        {
            if(raycastIdentity.collider.gameObject.tag == "TetriminoPiece")
            {
                if (raycastIdentity.collider.gameObject.GetComponent<Controls>().InPlay)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        return false;
    }
}
