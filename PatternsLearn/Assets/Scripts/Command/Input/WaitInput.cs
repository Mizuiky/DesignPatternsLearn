using UnityEngine;
using System;
using System.Collections.Generic;

public class WaitInput : MonoBehaviour
{
    #region Private Fields

    private string[] _forbiddenKeys = { "Mouse" };

    private bool _enableKeyPress;

    #endregion

    #region Properties
    public bool EnableKeyPress
    {
        get => _enableKeyPress;
        set => _enableKeyPress = value;
    }

    #endregion

    #region Events

    public static event Action<KeyCode> OnKeyPressed;

    #endregion

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _enableKeyPress = false;
    }

    void Update()
    {
        if (_enableKeyPress && Input.anyKeyDown)
        {
            GetInput();
        }
    }

    public void GetInput()
    {
        var keys = System.Enum.GetValues(typeof(KeyCode));

        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key) && !IsForbiddenKey(key))
            {
                Sendkey(key);
            }
        }
    }

    public void Sendkey(KeyCode key)
    {
        OnKeyPressed?.Invoke(key);
    }

    private bool IsForbiddenKey(KeyCode pressedKey)
    {
        foreach(string key in _forbiddenKeys)
        {
            if (pressedKey.ToString().Contains(key))
                return true;
        }

        return false;
    }
}
