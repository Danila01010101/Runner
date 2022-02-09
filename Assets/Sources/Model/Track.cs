public class Track
{
    public float XPosition { get; private set; }
    public Positions TrackPosition { get; private set; }
    public enum Positions { Left, Middle, Right };

    public Track(float xPosition, Positions position)
    {
        XPosition = xPosition;
        TrackPosition = position;
    }
}