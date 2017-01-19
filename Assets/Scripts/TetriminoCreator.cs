using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminoCreator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TetriminoDeployed()
    {
        Instantiate(Resources.Load("Prefabs/TetriminoPiece"), gameObject.transform.position, Quaternion.identity);
    }
}
