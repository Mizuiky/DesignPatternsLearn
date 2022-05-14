using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHandler
{
    private Stack<ICommand> _commands = new Stack<ICommand>();
    private ICommand _currentCommand;

    public void Execute(ICommand command)
    {
        _currentCommand = command;

        _commands.Push(_currentCommand);
        command.Execute();
    }

    public void Undo()
    {      
        if(_commands.Count > 0 )
        {        
            var command = _commands.Pop();

            if (command != null)
            {
                Debug.Log("COMMAND UNDO");
                command.Undo();
            }
        }      
    }

}
