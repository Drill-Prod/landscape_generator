using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public Text dimension_txt;
    public Text resolution_txt;
    public Text triangles_txt;
    public Text vertices_txt;


    public void Set_information(landscape_gen landscape)
    {
        dimension_txt.text = landscape.dimension.ToString();
        resolution_txt.text = landscape.resolution.ToString();
        triangles_txt.text = landscape.GetNbTriangles().ToString();
        vertices_txt.text = landscape.GetNbVertices().ToString();
    }
}
