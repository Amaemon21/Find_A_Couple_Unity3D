using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] private EnumAnimal _enumAnimal;

    private TransportationController _controller;
    private bool _isSet = false;

    public Rigidbody Rigidbody { get; private set; }
    public bool IsFist { get; private set; }
    public EnumAnimal EnumAnimal => _enumAnimal;

    public void Init(TransportationController controller)
    {
        _controller = controller;
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void SetFist() => IsFist = true;
    public void SetSecond() => IsFist = false;

    private void OnMouseDown()
    {
        if (!_isSet)
            SetAnimal();
        else
            ResetAnimal();
    }

    private void SetAnimal()
    {
        if (!_controller.IsFistEmpty && !_controller.IsSecondEmpty)
            return;

        _controller.SetAnimalToPlatform(this);
        _isSet = true;
        return;
    }

    private void ResetAnimal()
    {
        if (_controller.IsFistEmpty && _controller.IsSecondEmpty)
            return;

        _controller.ResetAnimalToPlatform(this);
        _isSet = false;
        return;
    }
}