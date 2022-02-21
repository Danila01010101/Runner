using UnityEngine;

[CreateAssetMenu(fileName = "New Skateboard", menuName = "Skateboard/Create new skateboard", order = 51)]
public class Skateboard : ScriptableObject
{
    [SerializeField] private float _lifeTimeInSeconds;
    [SerializeField] private GameObject _model;
    [SerializeField] private Vector3 _offset;

    public float LifeTimeInSeconds => _lifeTimeInSeconds;
    public Vector3 Offset => _offset;
    public GameObject Model => _model;
}
