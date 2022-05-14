using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Vector3 _direction;
    private Vector3 _originalPosition;

    private IGameEntity _gameEntity;

    public MoveCommand(Vector3 direction, IGameEntity gameEntity)
    {
        _gameEntity = gameEntity;
        _direction = direction * 1f;
        
        _originalPosition = gameEntity.EntityPosition.position;
    }

    public void Execute()
    {
        var moveTo = _originalPosition;
        moveTo += _direction;

        _gameEntity.MoveRigidbory(moveTo);
    }

    public void Undo()
    {
        var startPosition = _gameEntity.EntityPosition.position;

        Debug.Log("startPosition" + startPosition);
        Debug.Log("Original position " + _originalPosition);

        _gameEntity.MoveFromTo(startPosition, _originalPosition);
    }
}