using UnityEngine;

[RequireComponent(typeof(RunnerJumpView))]

public class RunnerPresenter : MonoBehaviour
{
    [SerializeField] private float _middleTrackPosition;
    [SerializeField] private float _trackGape;
    [SerializeField] private float _cameraTrackGape;
    [SerializeField] private TrackMovableObject _cameraMovementView;
    [SerializeField] private CollisionTrigger _collisionTrigger;
    [SerializeField] private Skateboard _startSkateboard;
    [SerializeField] private TrackMovableObject _runnerTrackMoveView;

    private RunnerJumpView _runnerJumpView;
    private RunnerView _runnerView;
    private Runner _runner;

    private void Awake()
    {
        if (_collisionTrigger == null)
            throw new System.NullReferenceException();
        _runner = new Runner(_middleTrackPosition, _trackGape, _cameraTrackGape);
        _runnerJumpView = GetComponent<RunnerJumpView>();
        _runnerView = GetComponent<RunnerView>();
    }
        
    private void Update()
    {
        _runner.Update();
        CheckInput();
    }

    private void CheckInput()
    {
        if (_runner.IsAlive)
        {
            if (Input.GetKeyDown(KeyCode.W))
                _runner.RunnerMovement.TryJump();
            else if (Input.GetKeyDown(KeyCode.D))
                _runner.RunnerMovement.ChangeTrack(Road.DirectionToMove.Right);
            else if (Input.GetKeyDown(KeyCode.A))
                _runner.RunnerMovement.ChangeTrack(Road.DirectionToMove.Left);
            else if (Input.GetKeyDown(KeyCode.E))
                _runner.ActivateSkateBoard(_startSkateboard);
        }
    }

    private void OnEnable()
    {
        _runner.RunnerMovement.TrackChanged += _runnerTrackMoveView.MoveAside;
        _runner.RunnerMovement.CameraTrackChanged += _cameraMovementView.MoveAside;
        _runner.RunnerMovement.OnJump += _runnerJumpView.Jump;
        _runnerJumpView.OnJumpEnd += _runner.RunnerMovement.JumpEnded;
        _runner.SkateboardAppeared += _runnerView.CreateSkateboard;
        _runner.SkateboardBroke += _runnerView.DestroySkate;
        Health.Death += _runnerView.PlayDeathAnimation;
        if (_collisionTrigger != null)
        {
            _collisionTrigger.CollisionHappened += _runner.CollideWithObject;
        }
    }

    private void OnDisable()
    {
        _runner.RunnerMovement.TrackChanged -= _runnerTrackMoveView.MoveAside;
        _runner.RunnerMovement.CameraTrackChanged -= _cameraMovementView.MoveAside;
        _runner.RunnerMovement.OnJump -= _runnerJumpView.Jump;
        _runnerJumpView.OnJumpEnd -= _runner.RunnerMovement.JumpEnded;
        _runner.SkateboardAppeared -= _runnerView.CreateSkateboard;
        _runner.SkateboardBroke -= _runnerView.DestroySkate;
        Health.Death -= _runnerView.PlayDeathAnimation;
        if (_collisionTrigger != null)
        {
            _collisionTrigger.CollisionHappened -= _runner.CollideWithObject;
        }
    }
}