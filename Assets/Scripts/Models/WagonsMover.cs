using PathCreation;
using UnityEngine;

public class WagonsMover : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private SpeedHandler speedHandler;
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

        distanceTravelled += speedHandler.speed * Time.deltaTime;

        for (var i = 0; i < wagonHolder.GetWagons().Count; i++)
        {
            var wagon = wagonHolder.GetWagons()[i];
            var point = distanceTravelled - i * wagonHolder.wagonDistance;
            var position = pathCreator.path.GetPointAtDistance(point, endOfPathInstruction);
            var rotation = pathCreator.path.GetRotationAtDistance(point, endOfPathInstruction);
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