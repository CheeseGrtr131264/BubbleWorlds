using UnityEngine;

public class UsesInput : MonoBehaviour
{
    protected InputMap _input;
    protected virtual void Awake()
    {
        _input = new InputMap();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}