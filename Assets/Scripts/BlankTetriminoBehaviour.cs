using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankTetriminoBehaviour : MonoBehaviour {

    bool m_selected;

	// Use this for initialization
	void Start () {
        m_selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSelection()
    {
        m_selected = !m_selected;
        if (m_selected)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(
                gameObject.GetComponent<Renderer>().material.color.r,
                gameObject.GetComponent<Renderer>().material.color.g,
                gameObject.GetComponent<Renderer>().material.color.b,
                1.0f
            );
        }else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(
                gameObject.GetComponent<Renderer>().material.color.r,
                gameObject.GetComponent<Renderer>().material.color.g,
                gameObject.GetComponent<Renderer>().material.color.b,
                0.5f
            );
        }
    }
}
