using DG.Tweening;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public void SitInWagon(Transform lastSit)
    {
        transform.SetParent(lastSit);
        AnimateToWagon();
    }

    private void AnimateToWagon()
    {
        transform.DOLocalMove(Vector3.zero, 1.5f);
    }
}