using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

public class Wagon : MovingOnRail
{
    [SerializeField] private List<Transform> sits;
    private bool CanPickUpPassenger => !sits.IsNullOrEmpty();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Passenger") || !CanPickUpPassenger) return;

        var passenger = other.GetComponent<Passenger>();
        passenger.SitInWagon(GetLastSit());
        PassengerFillEmptySit();
    }

    public Transform GetLastSit()
    {
        return sits[0];
    }

    private void PassengerFillEmptySit()
    {
        sits.RemoveAt(0);
    }
}