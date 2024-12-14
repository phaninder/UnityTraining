using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI displayText;
    [SerializeField]
    private Image backgroundImage;
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private Button buttonRef;

    [SerializeField]
    private Sprite newBackgroundSprite;
    [SerializeField]
    private GameObject panelRef;

    public void OnToggleChanged(bool value)
    {
        panelRef.SetActive(value);
        buttonRef.interactable = value;
    }

    public void OnButtonPressed()
    {
        displayText.text = "Hello, Welcome to Island!";
        backgroundImage.sprite = newBackgroundSprite;
    }

    public void OnSliderValueChanged(float newValue)
    {
        Debug.Log("Value is:" + newValue);
    }    

    public void OnScrollValueChanged(Vector2 Value)
    {
        Debug.Log("Value of scrool:" + Value);
    }

    public void OnDropDownSelected(int value)
    {
        Debug.Log("Color Selected =" + (PlayerColor)value);
    }

    public void OnInputFieldChanged(string value)
    {
        Debug.Log("Input Selected =" + value);
    }

    public void OnInputEnd(string value)
    {
        Debug.Log("Input End =" + value);
    }
}

public enum PlayerColor
{
    Blue,
    Red,
    Green,
    Yellow
}
