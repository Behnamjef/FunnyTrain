using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    public float speed;

    [SerializeField] private float maxSpeed;
    [Range(0, 1)] [SerializeField] private float gravityEffect;
    [SerializeField] private float motorPower;

    private Transform locomotive;

    void Start()
    {
        locomotive = GetComponent<WagonHolder>().GetWagons()[0].transform;
    }

    void Update()
    {
        ModifySpeed();
    }

    private void ModifySpeed()
    {
        var value = locomotive.eulerAngles.x;
        if (value > 180)
            value -= 360;
        speed += value * gravityEffect;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
    }
}