using System;
using UnityEngine;

public class SkateboardHealth : MonoBehaviour
{
    private Runner _runner;
    private int _skateboardHealth = 0;
    private float _skateboardSpawnTime;
    private float _skateboardLifeTime;

    public bool _isSkateboarding => _skateboardHealth > 0;

    public SkateboardHealth(Runner runner)
    {
        _runner = runner;
    }

    public void Update()
    {
        if (_isSkateboarding)
        {
            ScateboardTimerTick();
        }
    }

    public void InitializeNewSkateboard(Skateboard skateboard)
    {
        _skateboardLifeTime = skateboard.LifeTimeInSeconds;
        _skateboardHealth = 2;
        _skateboardSpawnTime = Time.time;
        _runner.SkateboardAppeared?.Invoke(skateboard);
    }

    public void TakeDamage()
    {
        if (_skateboardHealth > 0)
        {
            _skateboardHealth--;
            if (_skateboardHealth == 0)
                _runner.SkateboardBroke?.Invoke();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void BreakSkateboard()
    {
        _skateboardHealth = 0;
        _runner.SkateboardBroke?.Invoke();
    }

    private void ScateboardTimerTick()
    {
        if (Time.time - _skateboardSpawnTime >= _skateboardLifeTime)
        {
            _skateboardHealth = 0;
            _runner.SkateboardBroke?.Invoke();
        }
    }
}
