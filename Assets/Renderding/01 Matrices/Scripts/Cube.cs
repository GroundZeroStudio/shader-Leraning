/****************************************************
    文件：Cube.cs
    作者：Olivia
    日期：2022/10/12 21:22:29
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public int xSize, ySize, zSize;
    private Mesh m_Mesh;
    private Vector3[] m_Vertices;

    private void Awake()
    {
        
    }

    private IEnumerator Generate()
    {
        m_Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = m_Mesh;
        m_Mesh.name = "Procedural Cube";
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        yield return wait;
    }

    private void OnDrawGizmos()
    {
        if(m_Vertices == null)
            return;
        
        Gizmos.color = Color.black;
        for (int i = 0; i < m_Vertices.Length; i++)
        {
            Gizmos.DrawSphere(m_Vertices[i], 0.1f);
        }
    }
}
