using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Private Fields

    private Vector3 _direction;

    private Player _player;

    private InputReader _inputReader;

    private CommandHandler _commandHandler;

    #endregion

    void Start()
    {
        _inputReader = GetComponent<InputReader>();
        _player = GetComponent<Player>();

        _commandHandler = new CommandHandler();         
    }

    void Update()
    {
        _direction = _inputReader.ReadInput();     

        if(_inputReader.ReadUndo())
        {
            _commandHandler.Undo();
        }
    }

    void FixedUpdate()
    {
        if(_direction != Vector3.zero)
        {
            var moveCommand = new MoveCommand(_direction, _player);
            if (moveCommand != null)
            {
                _commandHandler.Execute(moveCommand);
            }
        }
    }
}
