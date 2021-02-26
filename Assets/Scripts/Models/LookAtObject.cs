using UnityEngine;

public class LookAtObject : MovingOnRail
{
    [SerializeField] private WagonsMover wagonsMover;
    [SerializeField] private float distanceTravelled;

    private void Start()
    {
        distanceTravelled = wagonsMover.GetPath().path.GetClosestDistanceAlongPath(transform.position);
    }

    private void Update()
    {
        distanceTravelled += wagonsMover.GetSpeed() * Time.deltaTime;

        var position = wagonsMover.GetPath().path.GetPointAtDistance(distanceTravelled);
        var rotation = wagonsMover.GetPath().path.GetRotationAtDistance(distanceTravelled);
        SetPositionAndRotation(position, rotation);
    }
}