using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : CommandBase, IMove
{
    private Vector3 _direction;
    private Vector3 _originalPosition;

    public Vector3 OriginalPosition
    {
        get => _originalPosition;    
        set => _originalPosition = value;   
    }

    public Vector3 Direction
    {
        get => _direction;
        set => _direction = value;
    }

    public override void SetEntity(IGameEntity gameEntity)
    {
        base.SetEntity(gameEntity);

        _originalPosition = gameEntity.EntityPosition.position;
    }

    public MoveCommand(Vector3 direction)
    {
        _direction = direction * 0.5f;

        Name = "Move";
    }

    public override void Execute()
    {
        Debug.Log("Execute");
        var moveTo = _originalPosition;

        moveTo += _direction;

        Entity.MoveRigidbory(moveTo);
    }

    public override void Undo()
    {
        Debug.Log("ORIGINAL POSITION UNDO: " + _originalPosition);

        Entity.MoveRigidbory(_originalPosition);
    }
}
