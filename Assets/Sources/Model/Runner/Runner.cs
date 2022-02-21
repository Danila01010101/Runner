using System;
using UnityEngine;

public class Runner
{
    private Health _runnerHealth;
    private SkateboardHealth _skateboardHealth;
    private RunnerMovement _runnerMovement;

    public bool IsAlive => _runnerHealth.HealthPoints > 0;
    public RunnerMovement RunnerMovement => _runnerMovement;
    public Action OnJump;
    public Action SkateboardBroke;
    public Action<Skateboard> SkateboardAppeared;

    public void Update()
    {
        _skateboardHealth.Update();
    }

    public Runner(float middleTrackPosition, float trackGape, float cameraTrackGape)
    {
        _runnerHealth = new Health();
        _skateboardHealth = new SkateboardHealth(this);
        _runnerMovement = new RunnerMovement(this, middleTrackPosition, trackGape, cameraTrackGape);
    }

    public void ActivateSkateBoard(Skateboard skateboard)
    {
        if (!_skateboardHealth._isSkateboarding)
        {
            _skateboardHealth.InitializeNewSkateboard(skateboard);
        }
    }

    public void CollideWithObject()
    {
        if (_skateboardHealth._isSkateboarding)
        {
            _skateboardHealth.BreakSkateboard();
        }
        else
        {
            _runnerHealth.Die();
        }
    }

    public void TakeDamage()
    {
        if (_skateboardHealth._isSkateboarding)
        {
            _skateboardHealth.TakeDamage();
        }
        else
        {
            _runnerHealth.TakeDamage();
        }
    }
}