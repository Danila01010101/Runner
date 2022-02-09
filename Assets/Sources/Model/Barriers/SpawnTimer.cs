using UnityEngine;

public class SpawnTimer
{
    private float _spawnInterval;
    private float _randomisedInterval;
    private float _spawnIntervalAccuracy;
    private float _passedTime;
    private Track _track;
    private BarriersFactory _factory;

    public SpawnTimer(BarriersFactory factory, Track track, float spawnInterval, float spawnIntervalAccuracy)
    {
        _factory = factory;
        _track = track;
        _spawnInterval = spawnInterval;
        _spawnIntervalAccuracy = spawnIntervalAccuracy;
        _randomisedInterval = _spawnInterval + Random.Range(0, _spawnIntervalAccuracy);
    }

    public void UpdateTimer()
    {
        _passedTime += Time.deltaTime;

        if (_passedTime >= _randomisedInterval)
        {   
            _factory.OnBarrierSpawn(_track.XPosition);
            _passedTime = 0;
            _randomisedInterval = _spawnInterval + Random.Range(0, _spawnIntervalAccuracy);
        }
    }
}
