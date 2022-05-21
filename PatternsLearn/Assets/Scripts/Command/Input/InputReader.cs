using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private Dictionary<KeyCode, IInputMap> _keyCommands;

    private void Awake()
    {
        InputScreen.UpdateInputMap += AssignInputToCommand;

        Init();
    }

    private void Init()
    {
        InitializeDefaultKeyCommands();
    }

    public void InitializeDefaultKeyCommands()
    {
        #region Initialing Dictionary

        _keyCommands = new Dictionary<KeyCode, IInputMap> ();

        _keyCommands.Add(KeyCode.A, new InputMap("Jump"));
        _keyCommands.Add(KeyCode.S, new InputMap("Attack"));

        _keyCommands.Add(KeyCode.RightArrow, new InputMapMovement("Move", 1, 0, 0));
        _keyCommands.Add(KeyCode.LeftArrow, new InputMapMovement("Move", -1, 0 , 0));
        _keyCommands.Add(KeyCode.UpArrow, new InputMapMovement("Move", 0, 0, 1));
        _keyCommands.Add(KeyCode.DownArrow, new InputMapMovement("Move", 0, 0, -1));

        #endregion

        PrintDictionary();
    }

    public void PrintDictionary()
    {
        foreach (KeyValuePair<KeyCode, IInputMap> command in _keyCommands)
        {
            Debug.Log("Key: " + command.Key.ToString() + "Name: " + command.Value.Name);
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        InputScreen.UpdateInputMap -= AssignInputToCommand;
    }

    public ICommand ReadCommand()
    {
        if (Input.anyKeyDown)
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
        var commandToChange = ValidateNewKeyCommand(commandName, key);

        if(commandToChange != KeyCode.None)
        {
            Debug.Log("UpdateKey");
            UpdateKeyCommand(_keyCommands[key], key);
        }
        
        foreach (KeyValuePair<KeyCode, IInputMap> command in _keyCommands)
        {
            Debug.Log("Key:" + command.Key + "Command Name:" + command.Value.Name);
        }
    }

    private void UpdateKeyCommand(IInputMap command, KeyCode key)
    {
        Debug.Log(command.Name);
        Debug.Log(key);

        _keyCommands.Remove(key);

        Debug.Log("UPDATE COMMANDS");
        foreach (KeyValuePair<KeyCode, IInputMap> commands in _keyCommands)
        {
            Debug.Log("Key:" + commands.Key + "Command Name:" + commands.Value.Name);
        }       

        _keyCommands.Add(key, new InputMap(command.Name));
    }

    private KeyCode ValidateNewKeyCommand(string commandName, KeyCode key)
    {
        if(_keyCommands.ContainsKey(key))
        {
            var result = _keyCommands[key].Name;

            if (_keyCommands[key].Name.Contains(commandName))
            return KeyCode.None;
        }

        Debug.Log("dont contain key");
        return key;
    }
}

#region InputMap

public class InputMap : IInputMap
{
    protected string _name;
    protected CommandBase _command;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public CommandBase Command
    {
        get => _command;
        set => _command = value;
    }

    public InputMap(string name)
    {
        _name = name;   
    }

    public virtual ICommand CreateNewCommand()
    {
        switch(_name)
        {
            case "Jump":               
                return new JumpCommand();
            case "Attack":
                return new AttackCommand();
        }

        return null;
    }
}

public class InputMapMovement : InputMap
{
    private Vector3 _direction;
    public Vector3 Direction
    {
        get => _direction;
        set => _direction = value;
    }

    //needed to refer base constructor in this children class constructor using :base(name)
    public InputMapMovement(string name, float x, float y, float z) : base(name)
    {
        _name = name;
        _direction = new Vector3(x, y, z);
    }

    public override ICommand CreateNewCommand()
    {    
        return new MoveCommand(_direction);
    }
}

public interface IInputMap
{
    public string Name { get; set; }

    public CommandBase Command { get; set; }

    public ICommand CreateNewCommand();
}

#endregion