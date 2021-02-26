using PathCreation;
using UnityEngine;

public class WagonsMover : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;
    
    private float distanceTravelled;
    private SpeedHandler speedHandler;
    private WagonHolder wagonHolder;

    private void Awake()
    {
        wagonHolder = GetComponent<WagonHolder>();
        speedHandler = GetComponent<SpeedHandler>();
    }

    private void Start()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }

    void Update()
    {
        if (pathCreator == null) return;

        distanceTravelled += speedHandler.speed * Time.deltaTime;

        for (var i = 0; i < wagonHolder.GetWagons().Count; i++)
        {
            var wagon = wagonHolder.GetWagons()[i];
            var point = distanceTravelled - i * wagonHolder.wagonDistance;
            var position = pathCreator.path.GetPointAtDistance(point);
            var rotation = pathCreator.path.GetRotationAtDistance(point);
            wagon.SetPositionAndRotation(position, rotation);
        }
    }

    public float GetSpeed()
    {
        return speedHandler.speed;
    }

    public PathCreator GetPath()
    {
        return pathCreator;
    }
}