using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NyetriminoList{
    public List<Nyetrimino> nyetriminos;

    public NyetriminoList()
    {
        nyetriminos = new List<Nyetrimino>();
    }

    public NyetriminoList(List<Nyetrimino> nyets)
    {
        nyetriminos = nyets;
    }
}
