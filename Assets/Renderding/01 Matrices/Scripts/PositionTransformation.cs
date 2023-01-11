/****************************************************
    文件：PositionTransformation.cs
    作者：Olivia
    日期：2022/10/30 11:26:35
    功能：Nothing
*****************************************************/

using UnityEngine;

public class PositionTransformation : Transformation
{
    public Vector3 position;

    public override Matrix4x4 Matrix
    {
        get
        {
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(1f, 0f, 0f, position.x));
            matrix.SetRow(1, new Vector4(0f, 1f, 0f, position.y));
            matrix.SetRow(2, new Vector4(0f, 0f, 1f, position.z));
            matrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
            return matrix;
        }
    }
}
