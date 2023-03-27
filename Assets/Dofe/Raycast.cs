using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SUUUUUUUUUU");
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        CheckForColliders();        
    }

    void CheckForColliders() {
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            Debug.Log(hit.collider.gameObject.name + " a était toucher !!");
        }
    }
}
