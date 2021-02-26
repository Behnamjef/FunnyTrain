using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOnRail : MonoBehaviour
{
    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        transform.eulerAngles = rot.eulerAngles + (Vector3.forward * 90);
    }
}
