using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    [SerializeField] private List<Transform> sits;
    private bool CanPickUpPassenger => !sits.IsNullOrEmpty();

    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        transform.eulerAngles = rot.eulerAngles + (Vector3.forward * 90);
    }

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