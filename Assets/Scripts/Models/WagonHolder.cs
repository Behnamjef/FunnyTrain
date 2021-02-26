using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class WagonHolder : MonoBehaviour
{
    [SerializeField] private Wagon wagonPrefab;
    [SerializeField] private List<Wagon> wagons;

    public float wagonDistance;

    [Button]
    private void CreateWagons(int count)
    {
        RemoveWagons();

        wagons = new List<Wagon> {GetComponent<Wagon>()};
        for (int i = 0; i < count; i++)
        {
            var wagon = PrefabUtility.InstantiatePrefab(wagonPrefab) as Wagon;
            wagons.Add(wagon);
        }

        SortWagons();
    }

    [Button]
    private void RemoveWagons()
    {
        wagons.Remove(GetComponent<Wagon>());
        for (int i = wagons.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(wagons[i].gameObject);
        }
    }

    [Button]
    private void SortWagons()
    {
        for (int i = 1; i < wagons.Count; i++)
        {
            wagons[i].transform.position = transform.position + Vector3.back * (i * wagonDistance);
        }
    }

    public List<Wagon> GetWagons()
    {
        return wagons;
    }
}