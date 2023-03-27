using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public int id;

    int[] voisin;

    public Point(int id, int[] voisin)
    {
        this.id = id;
        this.voisin = voisin;
        for(int i = 0; i < voisin.Length; i++)
        {
            if(voisin[i] < 0 )
            {
                voisin[i] = -1;
            }
        }
    }

    public int[] get_voisin()
    {
        return voisin;
    }
}
