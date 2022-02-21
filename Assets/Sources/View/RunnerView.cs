using UnityEngine;

public class RunnerView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _skater;

    private GameObject _currentSkate;
    private string _deathAnimationBoolName = "IsDead";
    private string _skatingAnimationBoolName = "IsOnBoard";

    public void PlayDeathAnimation()
    {
        _animator.SetBool(_deathAnimationBoolName, true);
    }

    public void CreateSkateboard(Skateboard skateboard)
    {
        var skateboardTransform = Instantiate(skateboard.Model).transform;
        _currentSkate = skateboardTransform.gameObject;
        skateboardTransform.SetParent(_skater);
        skateboardTransform.localPosition = skateboard.Offset;
        _animator.SetBool(_skatingAnimationBoolName, true);
    }

    public void DestroySkate()
    {
        _animator.SetBool(_skatingAnimationBoolName, false);
        Destroy(_currentSkate);
    }
}
