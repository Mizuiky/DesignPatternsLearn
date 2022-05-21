using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Private Fields

    private IGameEntity _player;

    private InputReader _inputReader;

    private CommandHandler _commandHandler;

    #endregion

    private void Awake()
    {
        
    }

    void Start()
    {
        _inputReader = FindObjectOfType<InputReader>();
        _player = FindObjectOfType<Player>();

        _commandHandler = new CommandHandler();
        _commandHandler.InitCommandHandler();
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            var command = _inputReader.ReadCommand();

            if (command != null)
            {
                command.SetEntity(_player);
                _commandHandler.Execute(command);
            }

            if (_inputReader.ReadUndo())
            {
                Debug.Log("READUNDO");
                _commandHandler.UndoMovements();
            }
        }
    }
}
