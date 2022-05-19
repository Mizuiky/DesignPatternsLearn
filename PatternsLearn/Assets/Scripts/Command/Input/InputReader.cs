using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private Dictionary<KeyCode, ICommand> _keyCommands;

    private void Awake()
    {
        InputScreen.UpdateInputMap += AssignInputToCommand;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        InitializeDefaultKeyCommands();
    }

    public void InitializeDefaultKeyCommands()
    {
        #region Initialing Dictionary

        _keyCommands = new Dictionary<KeyCode, ICommand>();

        _keyCommands.Add(KeyCode.A, new JumpCommand());
        _keyCommands.Add(KeyCode.S, new AttackCommand());

        _keyCommands.Add(KeyCode.RightArrow, new MoveCommand(Vector3.right));
        _keyCommands.Add(KeyCode.LeftArrow, new MoveCommand(-Vector3.right));
        _keyCommands.Add(KeyCode.UpArrow, new MoveCommand(Vector3.forward));
        _keyCommands.Add(KeyCode.DownArrow, new MoveCommand(-Vector3.forward));

        ReadDictionary();

        #endregion
    }

    public void ReadDictionary()
    {
        foreach (KeyValuePair<KeyCode, ICommand> command in _keyCommands)
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

    public ICommand ReadInput()
    {     
        if (Input.anyKey)
        {
            Debug.Log("Any Key Down");
            ICommand result = GetInput();

            if (result != null)
            {
                Debug.Log("READ INPUT != NULL");
                return result;
            }         
        }

        return null;
    }

    public ICommand GetInput()
    {
        var keys = System.Enum.GetValues(typeof(KeyCode));

        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
            {
                return CheckInput(key);
            }
        }

        return null;
    }

    private ICommand CheckInput(KeyCode key)
    {
        Debug.Log("CHECK KEY COMMAND");
        if (_keyCommands.ContainsKey(key))
        {
            Debug.Log("HAVE KEY");
            return _keyCommands[key];
        }

        return _keyCommands[key];
    }

    public bool ReadUndo()
    {
        Debug.Log("ESPACE");
        return Input.GetKeyDown(KeyCode.Space);
    }

    public void AssignInputToCommand(string commandName, KeyCode key)
    {
        Debug.Log("INPUT MESSAGE RECEIVED");

        foreach (KeyValuePair<KeyCode, ICommand> command in _keyCommands)
        {
            var updateKey = command.Key.ToString().Contains(key.ToString()) && command.Value.Name.Contains(commandName);

            if (!updateKey)
            {
                Debug.Log("UpdateKey");
                var value = command.Value;

                _keyCommands.Remove(key);

                _keyCommands.Add(key, value);
            }

            Debug.Log("Key: {0}, Value: {1}" + command.Key + command.Value);
        }
    }
}

public class InputResult: IInputResult
{
    private Vector3 _direction;
    private ICommand _command;

    public InputResult(Vector3 direction, ICommand command)
    {
        _direction = direction;
        _command = command;

        //_command.Init();
    }

    public Vector3 Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            _direction = value;
        }
    }

    public ICommand Command
    {
        get
        {
            return _command;
        }
    }  
}

public interface IInputResult
{
    public Vector3 Direction { get; }
    public ICommand Command { get; }
}

