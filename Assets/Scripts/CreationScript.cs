using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreationScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
        Vector3 originPoint = new Vector3(-5.0f, 10.0f, 0.0f);
        for(int i = 0; i < 14; i++)
        {
            for(int j = 0; j < 11; j++)
            {
                Instantiate(Resources.Load("Prefabs/BlankTetrimino"), originPoint + new Vector3(j, -i, 0), Quaternion.identity);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        //obtain the current mouse position as pixels from the bottom left of the screen
        Vector3 mousePos = Input.mousePosition;
        //create a temporary variable to store the camera position
        Vector3 newPos = gameObject.transform.position;
        //store the mouse position in a temporary variable
        Vector3 cameraToWorld = mousePos;
        //translate this position such that it is on the near clipping plane
        cameraToWorld.z = Camera.main.nearClipPlane;
        //obtain the world point of the near clipping plane
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(cameraToWorld);
        //use the world point of the mouse and the camera's position to get a direction
        //towards the world
        Vector3 cameraToWorldDirection = (worldPoint - gameObject.transform.position).normalized;
        //use this position to initialise a ray

        Ray x = new Ray(gameObject.transform.position, cameraToWorldDirection);
        //prepare a raycast towards where the mouse is pointing
        RaycastHit rch;
        Physics.Raycast(x, out rch);

        if (rch.collider != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(rch.collider.gameObject.tag == "BlankTetriminoPiece")
                {
                    rch.collider.gameObject.GetComponent<BlankTetriminoBehaviour>().OnSelection();
                }
            }
        }
    }

    public void Save()
    {
        NyetriminoList nyetriminosThatExist = JsonUtility.FromJson<NyetriminoList>(System.IO.File.ReadAllText("info.json"));
        if (nyetriminosThatExist == null)
        {
            nyetriminosThatExist = new NyetriminoList();
        }
        Nyetrimino n = new Nyetrimino();
        List<Vector3> positionsToAdd = new List<Vector3>();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("BlankTetriminoPiece"))
        {
            if (g.GetComponent<BlankTetriminoBehaviour>().IsSelected())
            {
                positionsToAdd.Add(g.transform.position);
            }
        }
        n.positions = positionsToAdd;
        nyetriminosThatExist.nyetriminos.Add(n);
        System.IO.File.WriteAllText("info.json", JsonUtility.ToJson(nyetriminosThatExist));
    }

    public void Quit()
    {
        GameObject.Find("Singleton").GetComponent<SingletonConfig>().ReturnToMainMenu();
    }
}
