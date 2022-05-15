using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IGameEntity
{
    private Rigidbody _bory;

    public Transform EntityPosition
    {
        get
        {
            return this.transform;
        }
    }

    void Awake()
    {
        _bory = GetComponent<Rigidbody>();
    }

    #region Movement

    public void MoveRigidbory(Vector3 positionToMove)
    {
        _bory.MovePosition(positionToMove);
    }

    #endregion
}
