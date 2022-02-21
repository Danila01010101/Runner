using UnityEngine;

public class BarrierView : MovingObject
{
    [SerializeField] private float _positionOffset;

    public float PositionOffset { get { return _positionOffset; } }
}