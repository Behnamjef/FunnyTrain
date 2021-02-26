using System;
using System.Linq;
using PathCreation;
using UnityEngine;

public class WagonsMover : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private float speed = 5;
    [SerializeField] private float distanceTravelled;

    private WagonHolder wagonHolder;

    private void Awake()
    {
        wagonHolder = GetComponent<WagonHolder>();
    }

    private void Start()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }

    void Update()
    {
        if (pathCreator == null) return;

        distanceTravelled += speed * Time.deltaTime;

        for (var i = 0; i < wagonHolder.GetWagons().Count; i++)
        {
            var wagon = wagonHolder.GetWagons()[i];
            var point = distanceTravelled - i * wagonHolder.wagonDistance;
            var position = pathCreator.path.GetPointAtDistance(point, endOfPathInstruction);
            var rotation = pathCreator.path.GetRotationAtDistance(point, endOfPathInstruction);
            wagon.SetPositionAndRotation(position, rotation);
        }
    }
}