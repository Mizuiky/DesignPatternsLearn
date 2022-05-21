using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CommandHandler
{
    private Stack<ICommand> _commands = new Stack<ICommand>();

    public void Execute(ICommand command)
    {
        Debug.Log("execute command handler");
        if(IsCommandType(command))
        {
            var mov = (MoveCommand)command;
            Debug.Log("Command Original position" + mov.OriginalPosition);

            _commands.Push(command);

            foreach (MoveCommand c in _commands)
            {
                Debug.Log("position keeped" + c.OriginalPosition);
            }
        }

        command.Execute();
    }

    public void InitCommandHandler()
    {
        _commands.Clear();
    }

    public async void UndoMovements()
    {
        //instead of using coroutine that is from monobehavior trying to create another class and link it with events just to pass all the command data to there, it's simpler to use the
        //Task.Delay that whe can use in normal classes to create a delay between the comands.

        while(_commands.Count > 0)
        {
            _commands.Pop().Undo();

            await Task.Delay(TimeSpan.FromSeconds(0.03f));
        }
    }

    private bool IsCommandType(ICommand command)
    {
        return command.GetType() == typeof(MoveCommand);
    }
}

