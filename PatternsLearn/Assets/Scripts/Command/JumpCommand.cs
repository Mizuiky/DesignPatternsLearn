using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private IGameEntity _gameActor;

    public JumpCommand(IGameEntity gameActor)
    {
        _gameActor = gameActor;
    }

    public virtual void Execute()
    {

    }

    public virtual void Undo()
    {

    }
}
