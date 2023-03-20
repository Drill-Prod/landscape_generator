using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfo : MonoBehaviour
{
    public Text dimension_txt;
    public Text resolution_txt;
    public Text triangles_txt;
    public Text vertices_txt;

    private landscape_gen landscape;

    public void Set_information()
    {
        landscape = GameObject.FindObjectOfType<landscape_gen>();
        dimension_txt.text = landscape.dimension.ToString();
        resolution_txt.text = landscape.resolution.ToString();
        triangles_txt.text = landscape.GetNbTriangles().ToString();
        vertices_txt.text = landscape.GetNbVertices().ToString();
    }
}
