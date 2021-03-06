using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputButtons : MonoBehaviour
{
    #region Private Fields

    #region Text Fields

    [SerializeField]
    private GameObject _pressAnyButtonText;

    #endregion

    #region Buttons

    [Header("Inputs")]

    [SerializeField]
    private Button _jumpBtn;

    [SerializeField]
    private Button _attackBtn;

    [SerializeField]
    private Button _rightBtn;

    [SerializeField]
    private Button _leftBtn;

    [SerializeField]
    private Button _upBtn;

    [SerializeField]
    private Button _downBtn;

    private bool _isAnyButtonBeingChanged;

    private Dictionary<string, Button> _inputButtons;

    #endregion

    #endregion

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Debug.Log("INIT INPUT BUTTONS ");
        _pressAnyButtonText.SetActive(false);

        _isAnyButtonBeingChanged = false;

        #region Init Input Dictionary

        _inputButtons = new Dictionary<string, Button>()
        {
            { "Jump" , _jumpBtn },
            { "Attack" , _attackBtn },
            { "Right" , _rightBtn },
            { "Left" , _leftBtn },
            { "Up" , _upBtn },
            { "Down" , _downBtn }

        };

        string [] keys = { "Z", "X", "D", "A", "W", "S" };

        var count = 0;

        foreach (var item in _inputButtons.Values)
        {
            item.interactable = true;
            item.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            item.GetComponentInChildren<TextMeshProUGUI>().text = keys[count];

            count++;
        }

        #endregion
    }

    public void SetButtonText(string type, string keyText)
    {
        Debug.Log("SET BUTTON TEXT:" + type);

        if (_inputButtons.ContainsKey(type))
        {
            _inputButtons[type].GetComponentInChildren<TextMeshProUGUI>().text = keyText;
        }

        SetButtonState(type, false);

        _pressAnyButtonText.SetActive(false);

        _isAnyButtonBeingChanged = false;
    }


    private void SetButtonState(string type, bool pressed)
    {
        if (_inputButtons.ContainsKey(type))
        {
            Debug.Log("LOCK CLICK ON: " + type);

            if (pressed)
            {
                _inputButtons[type].interactable = false;
                _inputButtons[type].GetComponentInChildren<TextMeshProUGUI>().color = Color.blue;
            }
            else
            {
                _inputButtons[type].interactable = true;
                _inputButtons[type].GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }
        }
    }

    public bool OnButtonPressed(string type)
    {
        Debug.Log("BUTTON PRESSED: " + type);
        if (_inputButtons.ContainsKey(type) && !_isAnyButtonBeingChanged)
        {
            _isAnyButtonBeingChanged = true;

            _pressAnyButtonText.SetActive(true);

            SetButtonState(type, true);

            return true;
        }

        Debug.Log("button being pressed");
        return false;
    }

    public Dictionary<string, Button> GetInputMap()
    {
        return _inputButtons;
    }
}
