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
        _commands.Push(command);
        command.Execute();
    }

    public async void Undo()
    {
        //instead of using coroutine that is from monobehavior trying to create another class and link it with events just to pass all the command data to there, it's simple to use the
        //Task.Delay that whe can use in normal classes to create a delay between the comands.

        while (_commands.Count > 0)
        {
            _commands.Pop().Undo();

            await Task.Delay(TimeSpan.FromSeconds(0.03f));
        }
    }
}

