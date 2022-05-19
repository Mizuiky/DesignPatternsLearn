using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBase : ICommand
{
    protected IGameEntity _gameEntity;

    protected string _name;
    public string Name
    {
        get
        {
            return _name;
        }
    }

    public CommandBase()
    {
        _name = "Base";
    }

    public virtual void Execute()
    {
        
    }

    public virtual void SetEntity(IGameEntity gameEntity)
    {
        _gameEntity = gameEntity;
    }

    public virtual void Undo()
    {
        
    }
}
