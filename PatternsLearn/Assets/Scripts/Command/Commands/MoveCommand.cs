using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : CommandBase
{
    private Vector3 _direction;
    private Vector3 _originalPosition;

    public Vector3 Direction
    {
        get
        {
            return _direction;
        }
    }

    public MoveCommand(Vector3 direction)
    {
        _direction = direction * 0.5f;
        base._name = "Move";
    }

    public override void Execute()
    {
        Debug.Log("Move Executed");

        _originalPosition = _gameEntity.EntityPosition.position;

        var moveTo = _originalPosition;
        moveTo += _direction;

        _gameEntity.MoveRigidbory(moveTo);
    }

    public override void Undo()
    {
        _gameEntity.MoveRigidbory(_originalPosition);
    }
}
