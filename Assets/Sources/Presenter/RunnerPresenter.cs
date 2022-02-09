using UnityEngine;

[RequireComponent(typeof(RunnerJumpView))]
[RequireComponent(typeof(RunnerJumpAsideView))]

public class RunnerPresenter : MonoBehaviour
{
    [SerializeField] private float _middleTrackPosition;
    [SerializeField] private float _trackGape;
    [SerializeField] private float _cameraTrackGape;
    [SerializeField] private TrackMovableObject _cameraMovement;
    [SerializeField] private CollisionTrigger _collisionTrigger;
    private RunnerJumpView _runnerJumpView;
    private RunnerJumpAsideView _runnerJumpAsideView;
    private Runner _runner;

    private void Awake()
    {
        if (_collisionTrigger == null)
            throw new System.NullReferenceException();
        _runner = new Runner(_middleTrackPosition, _trackGape, _cameraTrackGape);
        _runnerJumpView = GetComponent<RunnerJumpView>();
        _runnerJumpAsideView = GetComponent<RunnerJumpAsideView>();
    }
        
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (_runner.RunnerHealth.IsAlive)
        {
            if (Input.GetKeyDown(KeyCode.W))
                _runner.RunnerMovement.TryJump();
            else if (Input.GetKeyDown(KeyCode.D))
                _runner.RunnerMovement.ChangeTrack(Road.DirectionToMove.Right);
            else if (Input.GetKeyDown(KeyCode.A))
                _runner.RunnerMovement.ChangeTrack(Road.DirectionToMove.Left);
        }
    }

    private void OnEnable()
    {
        _runner.RunnerMovement.TrackChanged += _runnerJumpAsideView.MoveAside;

        _runner.RunnerMovement.CameraTrackChanged += _cameraMovement.MoveAside;

        _runner.RunnerMovement.OnJump += _runnerJumpView.Jump;

        Health.Death += _runnerJumpAsideView.PlayDeathAnimation;

        _runnerJumpView.OnJumpEnd += _runner.RunnerMovement.JumpEnded;

        if (_collisionTrigger != null)
            _collisionTrigger.CollisionHappened += _runner.RunnerHealth.CollideWithObject;
    }

    private void OnDisable()
    {
        _runner.RunnerMovement.TrackChanged -= _runnerJumpAsideView.MoveAside;

        _runner.RunnerMovement.CameraTrackChanged -= _cameraMovement.MoveAside;

        Health.Death -= _runnerJumpAsideView.PlayDeathAnimation;

        _runner.RunnerMovement.OnJump -= _runnerJumpView.Jump;

        _runnerJumpView.OnJumpEnd -= _runner.RunnerMovement.JumpEnded;

        if (_collisionTrigger != null)
            _collisionTrigger.CollisionHappened -= _runner.RunnerHealth.CollideWithObject;
    }
}