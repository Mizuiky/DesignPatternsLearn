using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField]
    private InputScreen _inputScreen;
   
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Debug.Log("INIT PAUSE SCREEN");
        EnableInputScreen(false);
    }

    public void Open(bool enable)
    {
        this.gameObject.SetActive(enable);
    }

    public void EnableInputScreen(bool open)
    {
        _inputScreen.Open(open);
    }

}
