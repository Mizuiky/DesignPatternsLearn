using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputScreen : MonoBehaviour
{
    #region Private Fields

    [SerializeField]
    private InputButtons _inputButtons;

    private WaitInput _waitInput;

    private bool _enableInput;

    private string _currentButtonPressed;

    #endregion

    #region Events

    public static event Action<string, KeyCode> UpdateInputMap;

    #endregion

    private void Awake()
    {
        Init();
    }
    private void OnEnable()
    {
        Activate();
    }

    private void OnDisable()
    {
        Deactivate();
    }

    public void Open(bool enable)
    {
        this.gameObject.SetActive(enable);
    }

    private void Activate()
    {
        _enableInput = false;

        _currentButtonPressed = "";

        WaitInput.OnKeyPressed += UpdateInputListener;
    }

    public void Deactivate()
    {
        _waitInput.EnableKeyPress = false;

        _currentButtonPressed = "";

        WaitInput.OnKeyPressed -= UpdateInputListener;
    }

    private void Init()
    {
        Debug.Log("INIT INPUT SCREEN");
        _waitInput = GetComponent<WaitInput>();
    }

    private void UpdateInputListener(KeyCode key)
    {
        if (_currentButtonPressed != "" && _waitInput.EnableKeyPress)
        {
            Debug.Log("Received Key");
            _waitInput.EnableKeyPress = false;
            _inputButtons.SetButtonText(_currentButtonPressed, key.ToString());

            UpdateInput(key);
        }
    }

    private void UpdateInput(KeyCode newKey)
    {
        Debug.Log("UpdateInput");

        UpdateInputMap?.Invoke(_currentButtonPressed, newKey);
    }

    public void OnButtonClick(string buttonName)
    {
        Debug.Log("Input Screen Button Click: " + buttonName);

        _enableInput = _inputButtons.OnButtonPressed(buttonName);

        EnableInput(_enableInput, buttonName);
    }

    public void EnableInput(bool enable, string button)
    {
        if (_enableInput)
        {
            Debug.Log("ENABLE INPUT");
            _waitInput.EnableKeyPress = true;
            _currentButtonPressed = button;

            Debug.Log("CURRENT BUTTON PRESSED " + _currentButtonPressed);
            return;
        }
    }
}
