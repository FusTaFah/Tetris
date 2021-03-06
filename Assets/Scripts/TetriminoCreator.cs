﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TetriminoCreator : MonoBehaviour {

    //[deprecated]
    List<List<Vector3>> m_patterns;
    NyetriminoList m_nyetriminos;
    public int depth;

    // Use this for initialization
    void Start() {
        m_patterns = new List<List<Vector3>>();

        List<Vector3> L = new List<Vector3>();
        L.Add(new Vector3(1.0f, 0.0f, 0.0f));
        L.Add(new Vector3(0.0f, 1.0f, 0.0f));
        L.Add(new Vector3(0.0f, 0.0f, 0.0f));
        L.Add(new Vector3(0.0f, 2.0f, 0.0f));
        m_patterns.Add(L);

        List<Vector3> O = new List<Vector3>();
        O.Add(new Vector3(0.0f, 0.0f, 0.0f));
        O.Add(new Vector3(0.0f, 1.0f, 0.0f));
        O.Add(new Vector3(1.0f, 0.0f, 0.0f));
        O.Add(new Vector3(1.0f, 1.0f, 0.0f));
        m_patterns.Add(O);

        List<Vector3> I = new List<Vector3>();
        I.Add(new Vector3(0.0f, 0.0f, 0.0f));
        I.Add(new Vector3(0.0f, 2.0f, 0.0f));
        I.Add(new Vector3(0.0f, 1.0f, 0.0f));
        I.Add(new Vector3(0.0f, 3.0f, 0.0f));
        m_patterns.Add(I);

        List<Vector3> Z = new List<Vector3>();
        Z.Add(new Vector3(0.0f, 0.0f, 0.0f));
        Z.Add(new Vector3(0.0f, 1.0f, 0.0f));
        Z.Add(new Vector3(-1.0f, 1.0f, 0.0f));
        Z.Add(new Vector3(1.0f, 0.0f, 0.0f));
        m_patterns.Add(Z);

        List<Vector3> DEBUG = new List<Vector3>();
        Vector3 originOfDebug = new Vector3(-5.0f, 0.0f, 0.0f);
        for(int i = 0; i < 11; i++)
        {
            for(int j = 0; j < depth; j++)
            {
                DEBUG.Add(originOfDebug + new Vector3(i, j, 0));
            }
        }
        m_patterns.Add(DEBUG);

        List<Vector3> DEBUG_STAGGERED = new List<Vector3>();
        for(int i = 0; i < 11; i += 2)
        {
            DEBUG_STAGGERED.Add(originOfDebug + new Vector3(i, 1.0f, 0.0f));
        }
        DEBUG_STAGGERED = DEBUG_STAGGERED.Concat(DEBUG).ToList();
        m_patterns.Add(DEBUG_STAGGERED);

        m_nyetriminos = JsonUtility.FromJson<NyetriminoList>(System.IO.File.ReadAllText("info.json"));

        TetriminoDeployed();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TetriminoDeployed()
    {
        //int shapeIndex = (int)(Mathf.Floor(Random.value * 4.0f));
        //shapeIndex = shapeIndex == 4 ? 3 : shapeIndex;
        //foreach(Vector3 position in m_patterns[shapeIndex])
        //{
        //    GameObject tetriminoPiece = (GameObject)Instantiate(Resources.Load("Prefabs/TetriminoPiece"), gameObject.transform.position + position, Quaternion.identity);
        //    tetriminoPiece.GetComponent<Controls>().InPlay = true;
        //    tetriminoPiece.GetComponent<Controls>().LocalTransform = position;
        //    tetriminoPiece.GetComponent<Renderer>().material.color =
        //        new Color(
        //            Mathf.Cos(shapeIndex) - Mathf.Sin(shapeIndex),
        //            Mathf.Sin(shapeIndex) + Mathf.Cos(shapeIndex),
        //            Mathf.Tan(shapeIndex));
        //}

        int shapeIndex = Mathf.Min(m_nyetriminos.nyetriminos.Count - 1, (int)(Mathf.Floor(Random.value * m_nyetriminos.nyetriminos.Count)));
        foreach (Vector3 position in m_nyetriminos.nyetriminos[shapeIndex].positions)
        {
            GameObject tetriminoPiece = (GameObject)Instantiate(Resources.Load("Prefabs/TetriminoPiece"), gameObject.transform.position + position, Quaternion.identity);
            tetriminoPiece.GetComponent<Controls>().InPlay = true;
            tetriminoPiece.GetComponent<Controls>().LocalTransform = position;
            tetriminoPiece.GetComponent<Renderer>().material.color =
                new Color(
                    Mathf.Cos(shapeIndex) - Mathf.Sin(shapeIndex),
                    Mathf.Sin(shapeIndex) + Mathf.Cos(shapeIndex),
                    Mathf.Tan(shapeIndex));
        }

    }
}
