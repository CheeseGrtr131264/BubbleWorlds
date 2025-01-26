using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UsesInput : MonoBehaviour
{
    protected InputMap _input;
    protected List<SmartButton> _smartButtonInputs = new(); 
    protected virtual void Awake()
    {
        _input = new InputMap();
    }

    protected virtual void OnEnable()
    {
        _input.Enable();
    }

    protected virtual void OnDisable()
    {
        _input.Disable();
    }

    protected virtual void Update()
    {
        foreach (SmartButton ia in _smartButtonInputs)
        {
            ia.Update();
        }
    }
}

public class SmartButton
{
    private InputAction _ia;
    private bool _wasTrueAlready;
    public SmartButton(InputAction ia)
    {
        _ia = ia;
    }

    public bool Value()
    {
        if (!_wasTrueAlready && Mathf.Approximately(_ia.ReadValue<float>(), 1))
        {
            _wasTrueAlready = true;
            return true;
        }

        return false;
    }
    public void Update()
    {
        if (_wasTrueAlready && Mathf.Approximately(_ia.ReadValue<float>(), 0))
        {
            _wasTrueAlready = false;
        }
    }
}