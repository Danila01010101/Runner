using System;
using System.Collections.Generic;

public class BarriersFactory
{
    private float _spawnInterval;
    private float _spawnIntervalAccuracy;
    private bool _isSpawning = true;
    private List<SpawnTimer> _timers;
    private Road _road = new Road(3, 0); 


    public Action<float> OnBarrierSpawn;

    public BarriersFactory(float interval, float intervalAccuracy)
    {
        _spawnInterval = interval;
        _spawnIntervalAccuracy = intervalAccuracy;
        _timers = new List<SpawnTimer>() { new SpawnTimer(this, _road.LeftTrack, _spawnInterval, _spawnIntervalAccuracy), 
            new SpawnTimer(this, _road.MiddleTrack, _spawnInterval, _spawnIntervalAccuracy), 
            new SpawnTimer(this, _road.RightTrack, _spawnInterval, _spawnIntervalAccuracy)};
    }

    public void Update()
    {
        if (_isSpawning)
        {
            foreach (SpawnTimer timer in _timers)
            {
                timer.UpdateTimer();
            }
        }
    }

    public void StopSpawning()
    {
        _isSpawning = false;
    }
}
