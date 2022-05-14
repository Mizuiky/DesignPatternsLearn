using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IGameEntity
{
    private Rigidbody _bory;

    private Coroutine _coroutine;

    public Transform EntityPosition
    {
        get
        {
            return this.transform;
        }
    }

    public Rigidbody Bory
    {
        get
        {
            return _bory;
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

    public void MoveFromTo(Vector3 starPosition, Vector3 endPosition)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            Debug.Log("BACK");              
        }

        Debug.Log("START");
        _coroutine = StartCoroutine(Move(starPosition, endPosition));
    }

    private IEnumerator Move(Vector3 starPosition, Vector3 endPosition)
    {
        float timeElapsed = 0;

        float duration = 1f;

        Debug.Log("LERP");

        while (timeElapsed < duration)
        {
            this.transform.position = Vector3.Lerp(starPosition, endPosition, timeElapsed/duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        Debug.Log("FORA");
        Debug.Log("endPosition: " + endPosition);
        this.transform.position = endPosition;
    }

    #endregion
}
