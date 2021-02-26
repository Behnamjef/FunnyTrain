using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class WagonHolder : MonoBehaviour
{
    public float wagonDistance;
    [SerializeField] private Wagon locomotivePrefab;
    [SerializeField] private Wagon wagonPrefab;
    [SerializeField] private List<Wagon> wagons;


    [Button]
    private void CreateWagons(int count)
    {
        RemoveWagons();

        wagons = new List<Wagon> {PrefabUtility.InstantiatePrefab(locomotivePrefab, transform) as Wagon};
        for (int i = 0; i < count; i++)
        {
            var wagon = PrefabUtility.InstantiatePrefab(wagonPrefab, transform) as Wagon;
            wagons.Add(wagon);
        }

        SortWagons();
    }

    private void RemoveWagons()
    {
        for (int i = wagons.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(wagons[i].gameObject);
        }
    }

    private void SortWagons()
    {
        for (int i = 0; i < wagons.Count; i++)
        {
            wagons[i].transform.localPosition = Vector3.back * (i * wagonDistance);
        }
    }

    public List<Wagon> GetWagons()
    {
        return wagons;
    }
}