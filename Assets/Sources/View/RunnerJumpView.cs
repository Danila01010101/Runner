using System;
using UnityEngine;

public class RunnerJumpView : MonoBehaviour
{
    [SerializeField] private RunnerPresenter _runnerPresenter;

    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _runnerTransform;
    [SerializeField] private float _jumpHeight = 1.2f;
    private string _jumpAnimationName = "Jump";
    private string _runAnimationName = "Run";
    private Vector3 _startPosition;
    private Vector3 _vector3Up = Vector3.up;
    private float _jumpAnimationDuration = 0.7f;
    private float _elapsedTime;
    private bool _isJumping = false;

    public Action OnJumpEnd;

    private void LateUpdate()
    {
        CheckJumping();
    }

    public void Jump()
    {
        _startPosition = _runnerTransform.position;
        _animator.Play(_jumpAnimationName);
        _isJumping = true;
    }

    private void CheckJumping()
    {
        if (_isJumping)
        {
            ContinueJump();
        }
    }

    private void ContinueJump()
    {
        _elapsedTime += Time.deltaTime;
        var a = _jumpCurve.Evaluate(_elapsedTime);
        _runnerTransform.position = new Vector3(_runnerTransform.position.x, _startPosition.y, _runnerTransform.position.z) + _vector3Up * _jumpCurve.Evaluate(_elapsedTime) * _jumpHeight;
        if (_elapsedTime > _jumpAnimationDuration)
            EndJump();
    }

    private void EndJump()
    {
        _elapsedTime = 0;
        _animator.Play(_runAnimationName);
        transform.position = _startPosition;
        _isJumping = false;
        if (OnJumpEnd != null)
            OnJumpEnd();
    }
}
