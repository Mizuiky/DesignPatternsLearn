using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Private Fields

    private IGameEntity _player;

    private InputReader _inputReader;

    private CommandHandler _commandHandler;

    private CommandBase _currentCommand;

    #endregion

    private void Awake()
    {
        _currentCommand = new CommandBase();
    }

    void Start()
    {
        _inputReader = FindObjectOfType<InputReader>();
        _player = FindObjectOfType<Player>();

        _commandHandler = new CommandHandler();     
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            _currentCommand = (CommandBase)_inputReader.ReadInput();
            
            if (_inputReader.ReadUndo())
            {
                Debug.Log("READUNDO");
                _commandHandler.Undo();
            }        
        }
    }

    void FixedUpdate()
    {
        //isso aqui precisa melhorar
        if(!_currentCommand.Name.Contains("Base"))
        {
            Debug.Log("ACTIVATE NEW COMMAND");
            _currentCommand.SetEntity(_player);
            _commandHandler.Execute(_currentCommand);
        }
    }
}
