using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public Text dimension_txt;
    public Text resolution_txt;
    public Text triangles_txt;
    public Text vertices_txt;

    public Point[] est_passe;

    public bool useMove = true;
    public bool useChange = false;
    public bool usePath = false;
    public bool useExtend = false;

    private void Awake()
    {
        _instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Game Manager is NULL");
            return _instance;
        }
    }


    public void Set_information(landscape_gen landscape)
    {
        dimension_txt.text = landscape.dimension.ToString();
        resolution_txt.text = landscape.GetResolution().ToString();
        triangles_txt.text = landscape.GetNbTriangles().ToString();
        vertices_txt.text = landscape.GetNbVertices().ToString();
    }

    public void Moving()
    {
        useChange=false;
        usePath=false;
        useMove=true;
        useExtend=false;
        Debug.Log("Moving");
    }

    public void Changing()
    {
        useChange=true;
        usePath=false;
        useMove=false;
        useExtend=false;
        Debug.Log("Chnage le terrain");
    }

    public void Pathin()
    {
        useChange=false;
        usePath=true;
        useMove=false;
        useExtend=true;
        Debug.Log("De A a B");
    }

    public void Extend()
    {
        useChange=false;
        usePath=false;
        useMove=false;
        useExtend=true;
        Debug.Log("Ajouter du terrain");
    }
}
