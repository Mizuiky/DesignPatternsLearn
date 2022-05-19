using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEntity 
{
    public Transform EntityPosition { get; }

    public void MoveRigidbory(Vector3 positionToMove);

    //here we put any kind of elements that Players and enemies have in comum into the game
}
