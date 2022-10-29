using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeshSubdivider : MonoBehaviour
{
    public int Subdivisions;
    public TextAsset Body;
    private MeshFilter meshFilter;
    private QuadMeshData meshData;
    private QuadOBJParser parser;

    void Start()
    {
        parser = new QuadOBJParser();
        meshFilter = GetComponent<MeshFilter>();
        ShowMesh();
       for(int i=0;i<Subdivisions;i++)
        {
        Subdivide();
        }
    }

    void ShowMesh()
    {
        meshData = parser.Parse(Body);
        meshFilter.mesh = meshData.ToUnityMesh();
    }

    void Subdivide()
    {
        meshData = CatmullClark.Subdivide(meshData);
        meshFilter.mesh = meshData.ToUnityMesh();
    }


}
