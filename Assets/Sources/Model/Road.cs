public class Road
{
    private float _trackGape;
    public Track CurrentTrack { get; private set; }
    public Track LeftTrack { get; private set; }
    public Track MiddleTrack { get; private set; }
    public Track RightTrack { get; private set; }
    public enum DirectionToMove { Right, Left };

    public Road(float trackGape, float middleTrackXPosition)
    {
        _trackGape = trackGape;
        MiddleTrack = new Track(middleTrackXPosition, Track.Positions.Middle);
        LeftTrack = new Track(middleTrackXPosition - _trackGape, Track.Positions.Left);
        RightTrack = new Track(middleTrackXPosition + _trackGape, Track.Positions.Right);
        CurrentTrack = MiddleTrack;
    }

    public bool TryChangeTrack(DirectionToMove directionToMove)
    {
        switch (directionToMove)
        {
            case DirectionToMove.Right:
                if (CurrentTrack.TrackPosition == Track.Positions.Left)
                {
                    CurrentTrack = MiddleTrack;
                    return true;
                }
                else if (CurrentTrack.TrackPosition == Track.Positions.Middle)
                {
                    CurrentTrack = RightTrack;
                    return true;
                }
                else if (CurrentTrack.TrackPosition == Track.Positions.Right)
                {
                    return false;
                }
                break;
            case DirectionToMove.Left:
                if (CurrentTrack.TrackPosition == Track.Positions.Right)
                {
                    CurrentTrack = MiddleTrack;
                    return true;
                }
                else if (CurrentTrack.TrackPosition == Track.Positions.Middle)
                {
                    CurrentTrack = LeftTrack;
                    return true;
                }
                else if (CurrentTrack.TrackPosition == Track.Positions.Left)
                {
                    return false;
                }
                break;
        }
        return false;
    }
}