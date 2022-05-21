using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBase : ICommand
{
    private string _name;
    private IGameEntity _entity;


    public IGameEntity Entity
    {
        get
        {
            return _entity;
        }
        set
        {
            _entity = value;
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public virtual void Execute()
    {
        Debug.Log("Execute command");
    }

    public virtual void SetEntity(IGameEntity gameEntity)
    {
        _entity = gameEntity;
    }

    public virtual void Undo()
    {
        Debug.Log("Undo command");
    }
}
