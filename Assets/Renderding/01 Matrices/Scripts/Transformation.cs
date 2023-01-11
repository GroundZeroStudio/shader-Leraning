/****************************************************
    文件：Transformation.cs
    作者：Olivia
    日期：2022/10/30 11:13:35
    功能：Nothing
*****************************************************/

using UnityEngine;

public abstract class Transformation : MonoBehaviour
{
    public abstract Matrix4x4 Matrix { get; }

    //public abstract Vector3 Apply(Vector3 point);

    public Vector3 Apply(Vector3 point)
    {
        return Matrix.MultiplyPoint(point);
    }
}
