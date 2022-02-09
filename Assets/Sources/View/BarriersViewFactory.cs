using System.Collections.Generic;
using UnityEngine;

public class BarriersViewFactory : MonoBehaviour
{
    [SerializeField] private List<BarrierView> _randomBarrierPrefabs;
    [SerializeField] private Transform _barrierParent;
    [SerializeField] private Transform _startPosition;

    public void SpawnNewRandomBarrier(float xPositionOnTrack)
    {
        int index = Random.Range(0, _randomBarrierPrefabs.Count);
        Instantiate(_randomBarrierPrefabs[index].gameObject,
            _startPosition.position + Vector3.right * xPositionOnTrack + Vector3.right * _randomBarrierPrefabs[index].PositionOffset, 
            _randomBarrierPrefabs[index].transform.rotation);
    }
}
