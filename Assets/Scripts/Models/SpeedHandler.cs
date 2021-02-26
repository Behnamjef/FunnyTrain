using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandler : MonoBehaviour
{
    public float speed;

    [SerializeField] private float maxSpeed;
    [Range(0.001f, 2)] [SerializeField] private float gravityEffect;
    [Range(0, 2)] [SerializeField] private float motorPower;

    private Transform locomotive;
    private InputHandler inputHandler;

    void Start()
    {
        locomotive = GetComponent<WagonHolder>().GetWagons()[0].transform;
        inputHandler = GetComponent<InputHandler>();
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
        speed += value / (20 / gravityEffect) + (inputHandler.isTouching ? motorPower : 0);
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
    }
}