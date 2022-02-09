using System;
using UnityEngine;

public class RunnerJumpAsideView : TrackMovableObject
{
    [SerializeField] private Animator _animator;
    private string _deathAnimationBoolName = "IsDead";

    public void PlayDeathAnimation()
    {
        _animator.SetBool(_deathAnimationBoolName, true);
    }
}
