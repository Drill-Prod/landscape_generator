using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class landscape_gen : MonoBehaviour
{
    public int dimension;
    public int resolution;

    private Vector3[] p_vertices;
    private Point[] p_points;
    private Vector3[] p_normals;
    private int[] p_triangles;
    private Mesh p_mesh;

    float x = 0;
    float z = 0;
    int cpt = 0;


    // Start is called before the first frame update
    void Start()
    {
        p_points = new Point[resolution * resolution];
        p_mesh = new Mesh();
        p_mesh.Clear();
        p_mesh.name = "landscape";
        p_vertices = new Vector3[resolution * resolution];
        int tmp_grid_N = resolution - 1;
        tmp_grid_N = tmp_grid_N * tmp_grid_N * 6;
        p_triangles = new int[tmp_grid_N];

        float ecart = dimension / resolution;

        //--------------------- Vertices -----------------------//
        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                p_vertices[cpt] = new Vector3(x, 0, z);
                print(p_vertices[cpt]);
                cpt++;
                x += ecart;
            }
            x = 0;
            z += ecart;
        }

        //--------------------- triangles -----------------------//

        int z_disp, leftDown, leftUp, rightDown, rightUp = 0;
        int cpt_triangles = 0;

        for (int z_boucle = 0; z_boucle < resolution - 1; z_boucle++)
        {
            for (int x_boucle = 0; x_boucle < resolution - 1; x_boucle++)
            {
                z_disp = resolution * z_boucle;
                leftDown = x_boucle + z_disp;
                leftUp = resolution + z_disp + x_boucle;
                rightDown = leftDown + 1;
                rightUp = leftUp + 1;
                p_triangles[cpt_triangles] = leftDown;
                p_triangles[cpt_triangles + 1] = leftUp;
                p_triangles[cpt_triangles + 2] = rightDown;

                p_triangles[cpt_triangles + 3] = rightUp;
                p_triangles[cpt_triangles + 4] = rightDown;
                p_triangles[cpt_triangles + 5] = leftUp;

                //-- calcul des voisins
                int[] voisin_temp = { leftDown + resolution, leftDown++, leftDown - resolution, leftDown-- };
                p_points[leftDown] = new Point(leftDown, voisin_temp, this);

                cpt_triangles += 6;
            }
        }

        p_mesh.vertices = p_vertices;
        p_mesh.triangles = p_triangles;
        GetComponent<MeshFilter>().mesh = p_mesh;
        GetComponent<MeshCollider>().mesh = p_mesh;

        MeshCollider.Instantiate(p_mesh);
    }

    public void deformation(int point_milieu)
    {

        GameObject.FindObjectOfType<GameManager>().Set_information(this);
    }

    public int GetNbTriangles() { return p_triangles.Length/3; }

    public int GetNbVertices() { return p_vertices.Length; }

    public int GetResolution() { return resolution; }

} 
