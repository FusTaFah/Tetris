using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    bool m_inPlay;
    float m_fallDelay;
    float m_timer;
    public bool InPlay { get { return m_inPlay; } set { m_inPlay = value; } }
    public float FallDelay { get { return m_fallDelay; } set { m_fallDelay = value; } }

	// Use this for initialization
	void Start () {
        m_inPlay = true;
        m_fallDelay = 1.0f;
        m_timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (InPlay)
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_fallDelay)
            {
                if (!checkBounds(new Vector3(0.0f, -1.0f, 0.0f)))
                {
                    gameObject.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
                }
                else
                {
                    m_inPlay = false;
                    foreach (GameObject g in GameObject.FindGameObjectsWithTag("TetriminoPiece"))
                    {
                        g.GetComponent<Controls>().InPlay = false;
                    }
                    GameObject.Find("TetriminoFactory").GetComponent<TetriminoCreator>().TetriminoDeployed();
                }
                m_timer = 0.0f;
            }
        }
        
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
