using UnityEngine;

[RequireComponent(typeof(WagonHolder), typeof(WagonsMover))]
public class Train : MonoBehaviour
{
    private WagonHolder wagonHolder;
    private WagonsMover wagonsMover;

    private void Awake()
    {
        wagonHolder = GetComponent<WagonHolder>();
        wagonsMover = GetComponent<WagonsMover>();
    }
}