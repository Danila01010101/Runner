using UnityEngine;

public class BarrierSpawnerPresenter : MonoBehaviour
{
    [SerializeField] private BarriersViewFactory _barriersViewFactory;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _spawnIntervalAccuracy;
    private BarriersFactory _barriersFactory;

    public enum Track { Left, Middle, Right }

    private void Awake()
    {
        _barriersFactory = new BarriersFactory(_spawnInterval, _spawnIntervalAccuracy);
    }

    private void Update()
    {
        _barriersFactory.Update();
    }

    private void OnEnable()
    {
        _barriersFactory.OnBarrierSpawn += _barriersViewFactory.SpawnNewRandomBarrier;
        Health.Death += _barriersFactory.StopSpawning;
    }

    private void OnDisable()
    {
        _barriersFactory.OnBarrierSpawn -= _barriersViewFactory.SpawnNewRandomBarrier;
        Health.Death -= _barriersFactory.StopSpawning;
    }
}
