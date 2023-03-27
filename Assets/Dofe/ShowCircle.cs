using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCircle : MonoBehaviour
{
    public Material terrainMaterial;
    public Vector3 mousePos;

    private RaycastHit _Hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out _Hit)) {
            mousePos = new Vector3(_Hit.point.y, _Hit.point.z);

            Debug.Log("SUUUUUUUUUU: (" + mousePos.x + "," + mousePos.y + "," + mousePos.z + ")");

            terrainMaterial.SetVector("AreaCenter", new Vector4(mousePos.x, mousePos.y, mousePos.z, 0f));
        }    
    }
}
