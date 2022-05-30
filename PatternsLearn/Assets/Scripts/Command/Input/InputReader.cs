using System;
using System.Collections.Generic;
using UnityEngine;
using InputCollection;

public class InputReader : MonoBehaviour
{
    private Dictionary<KeyCode, IInputMap> _keyCommands;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        InputController.UpdateInputMap += AssignInputToCommand;

        InitializeDefaultKeyCommands();
    }

    public void InitializeDefaultKeyCommands()
    {
        #region Initialing Dictionary

        _keyCommands = new Dictionary<KeyCode, IInputMap> ();

        _keyCommands.Add(KeyCode.Z, new InputMap("Jump"));
        _keyCommands.Add(KeyCode.X, new InputMap("Attack"));

        _keyCommands.Add(KeyCode.D, new InputMapMovement("Right", 1, 0, 0));
        _keyCommands.Add(KeyCode.A, new InputMapMovement("Left", -1, 0 , 0));
        _keyCommands.Add(KeyCode.W, new InputMapMovement("Up", 0, 0, 1));
        _keyCommands.Add(KeyCode.S, new InputMapMovement("Down", 0, 0, -1));

        #endregion

        PrintDictionary();
    }

    public void PrintDictionary()
    {
        foreach (KeyValuePair<KeyCode, IInputMap> command in _keyCommands)
        {
            Debug.Log("Key: " + command.Key.ToString() + " " + "Name: " + command.Value.Name);
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        InputController.UpdateInputMap -= AssignInputToCommand;
    }

    public ICommand ReadCommand()
    {
        if (Input.anyKey)
        {
            var key = GetInput();

            if (key != KeyCode.None)
            {
                return GetCommand(key);
            }
        }

        return null;
    }

    public KeyCode GetInput()
    {
        var keys = System.Enum.GetValues(typeof(KeyCode));

        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
            {
                return key;
            }
        }

        return KeyCode.None;
    }

    private ICommand GetCommand(KeyCode key)
    {
        if (_keyCommands.ContainsKey(key))
        {
            return _keyCommands[key].CreateNewCommand();
        }
        return null;
    }

    public bool ReadUndo()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public void AssignInputToCommand(string commandName, KeyCode key)
    {
        if(ShouldAddNewInput(commandName, key))
        {
            Debug.Log("UpdateKey");
            UpdateInput(commandName, key);
        }

        PrintDictionary();
    }

    private bool ShouldAddNewInput(string pressedCommandName, KeyCode key)
    {
        if (_keyCommands.ContainsKey(key))
        {
            var currentCommandName = _keyCommands[key].Name;
            if (currentCommandName.Contains(pressedCommandName))
                return false;
            else
                return true;
        }

        Debug.Log("dont contain key");
        return true;
    }

    private void UpdateInput(string commandName, KeyCode newKey)
    {
        var currentInputMap = GetCurrentInput(commandName);

        if(currentInputMap != null)
        {
            _keyCommands.Remove(currentInputMap.Key);

            _keyCommands.Add(newKey, currentInputMap.Input);
        }  
    }

    private IInputPackage GetCurrentInput(string commandName)
    {
        foreach (KeyValuePair<KeyCode, IInputMap> input in _keyCommands)
        {
            if (input.Value.Name.Contains(commandName))
                return new InputPackage(input.Key, input.Value);
        }

        return null;
    }
}
