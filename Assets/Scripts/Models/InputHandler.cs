using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public bool isTouching;

    private void Update()
    {
        isTouching = Input.GetMouseButton(0);
    }
}
