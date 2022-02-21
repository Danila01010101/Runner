using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private Transform _objectTransform;
    [SerializeField] private float _speed = 1f;

    private bool _isGameRunning = true;

    public Transform ObjectTransform { get { return _objectTransform; } }

    private void LateUpdate()
    {
        if (_isGameRunning)
        {
            _objectTransform.position -= Vector3.forward * _speed;
        }
    }

    private void OnEnable()
    {
        Health.Death += StopMovement;
    }

    private void OnDisable()
    {
        Health.Death -= StopMovement;
    }

    public void StopMovement()
    {
        _isGameRunning = false;
    }
}
