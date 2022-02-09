using UnityEngine;

public class FloorView : MovingObject
{
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = ObjectTransform.position;
    }

    private void Update()
    {
        if (ObjectTransform.position.z <= -30f)
            ObjectTransform.position = _startPosition;
    }
}
