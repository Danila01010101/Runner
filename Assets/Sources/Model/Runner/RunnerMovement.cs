using System;
public class RunnerMovement
{
    private Runner _runner;
    private Road _track;
    private Road _cameraTrack;
    public bool CanMove { get; private set; } = true;
    private bool _canJump = true;

    public Action OnJump;
    public Action<Road.DirectionToMove, float, bool> TrackChanged;
    public Action<Road.DirectionToMove, float, bool> CameraTrackChanged;

    public RunnerMovement(Runner runner, float middleTrackPosition, float trackGape, float cameraTrackGape)
    {
        _runner = runner;
        _track = new Road(trackGape, middleTrackPosition);
        _cameraTrack = new Road(cameraTrackGape, middleTrackPosition);
    }

    public void TryJump()
    {
        if (_canJump && CanMove && OnJump != null)
        {
            _canJump = false;
            OnJump();
        }
    }

    public void JumpEnded()
    {
        _canJump = true;
    }

    public void ChangeTrack(Road.DirectionToMove directionToMove)
    {
        if (CanMove)
        {
            if (_track.TryChangeTrack(directionToMove))
            {
                if (TrackChanged != null)
                {
                    _cameraTrack.TryChangeTrack(directionToMove);
                    TrackChanged(directionToMove, _track.CurrentTrack.XPosition, true);
                    CameraTrackChanged(directionToMove, _cameraTrack.CurrentTrack.XPosition, true);
                }
            }
            else
            {
                TrackChanged(directionToMove, _track.CurrentTrack.XPosition, false);
                _runner.TakeDamage();
            }
        }
    }
}