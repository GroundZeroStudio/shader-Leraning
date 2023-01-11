/****************************************************
    文件：Grid.cs
    作者：Olivia
    日期：2022/10/1 16:38:29
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    public int xSize, ySize;

    private Vector3[] m_Vertices;
    
    private void Awake()
    {
        Create();
    }

    private Mesh m_Mesh;
    private void Create()
    {
        m_Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = m_Mesh;
        m_Mesh.name = "Procedural Grid";
        m_Vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        Vector2[] uv = new Vector2[m_Vertices.Length];
        Vector4[] tangents = new Vector4[m_Vertices.Length];
        Vector4 tangent = new Vector4(1f, 0f, 0, -1f);
        int i = 0;
        for (int y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                m_Vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
                tangents[i] = tangent;
                i++;
            }
        }
        m_Mesh.vertices = m_Vertices;
        m_Mesh.uv = uv;
        m_Mesh.tangents = tangents;
        //在 Mesh 类中，顶点全部存储在单个数组中，并且每个三角形使用与顶点数组的索引对应的三个整数指定。
        //这些三角形还将全部集合在一个整数数组中；从该数组的开头以三个为一组的方式解读数组中的整数，因此元素 0、1 和 2 定义第一个三角形，3、4 和 5 定义第二个三角形 
        int[] triangles = new int[xSize * ySize * 6];
        int ti = 0;
        int vi = 0;
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
                vi++;
                ti += 6;
                m_Mesh.triangles = triangles;
                //Unity 通过对网格几何形状的“意义”进行一些假设来计算法线的方向；假设三角形之间共享的顶点表示光滑的表面，而加倍的顶点表示清晰的边缘。 
                m_Mesh.RecalculateNormals();
            }
            vi++;
        }
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
