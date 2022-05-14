using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEntity 
{
    public Transform EntityPosition { get; }

    public Rigidbody Bory { get; }

    public void MoveRigidbory(Vector3 positionToMove);

    public void MoveFromTo(Vector3 starPosition, Vector3 endPosition);

    //here we put any kind of actions that the player or enemies will do in the game
}
