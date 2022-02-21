using UnityEngine;

public class TrackMovableObject : MonoBehaviour
{
    [SerializeField] private Transform _transformToMove;
    [SerializeField] private float _moveSpeed;

    private float _currentTrackXPosition;
    private Vector3 _vector3Right = Vector3.right;
    private Vector3 _vector3Left = Vector3.left;
    private Vector3 _currentDirection;
    private bool _isMoving = false;

    public void MoveAside(Road.DirectionToMove directionToMove, float trackXPosition, bool isSuccessfull)
    {
        if (isSuccessfull)
        {
            if (directionToMove == Road.DirectionToMove.Right)
                _currentDirection = _vector3Right;
            else if (directionToMove == Road.DirectionToMove.Left)
                _currentDirection = _vector3Left;
            _currentTrackXPosition = trackXPosition;
            _isMoving = true;
        }
    }

    private void CheckMovement()
    {
        if (_isMoving)
        {
            ContinueMovement();
        }
    }

    private void ContinueMovement()
    {
        _transformToMove.position += _currentDirection * _moveSpeed;
        if (_currentDirection.x > 0)
        {
            if (_transformToMove.position.x > _currentTrackXPosition)
                EndMoving();
        }
        else
        {
            if (_transformToMove.position.x < _currentTrackXPosition)
                EndMoving();
        }
    }

    private void EndMoving()
    {
        _isMoving = false;
    }

    private void LateUpdate()
    {
        CheckMovement();
    }
}
