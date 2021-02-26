using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmozDrawer : MonoBehaviour
{
    public float radius = 3;
    public DrawType drawType;
    public Color color = Color.red;

    public enum DrawType
    {
        Sphere,
        WireSphere
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        switch (drawType)
        {
            case DrawType.WireSphere:
                Gizmos.DrawWireSphere(transform.position, radius);
                break;
            case DrawType.Sphere:
                Gizmos.DrawSphere(transform.position, radius);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
#endif
}