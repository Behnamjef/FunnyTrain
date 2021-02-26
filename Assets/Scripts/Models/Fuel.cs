using System;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [SerializeField] private float amount;
    [SerializeField] private float maxAmount;
    [SerializeField] private Image fuelBarImage;
    private InputHandler inputHandler;

    private void Awake()
    {
        amount = maxAmount;
        inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        if (!inputHandler.isTouching || IsEmpty()) return;

        amount -= Time.deltaTime;
        fuelBarImage.fillAmount = amount / maxAmount;
    }

    public bool IsEmpty()
    {
        return amount <= 0;
    }
}