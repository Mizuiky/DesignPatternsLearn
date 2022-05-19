using System;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Private Fields

    [SerializeField]
    private PauseScreen _pauseScreen;

    #endregion

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _pauseScreen.Open(false);
    }

    public void EnablePauseScreen(bool enable)
    {
        if (enable)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        _pauseScreen.Open(enable);
    }

}
