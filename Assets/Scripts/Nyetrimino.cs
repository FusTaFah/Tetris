using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Nyetrimino{
    public List<Vector3> positions;

    public Nyetrimino()
    {
        positions = new List<Vector3>();
    }
    public Nyetrimino(List<Vector3> p)
    {
        positions = p;
    }
}
