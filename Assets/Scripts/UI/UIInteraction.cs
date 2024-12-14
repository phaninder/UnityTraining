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
    private Sprite newBackgroundSprite;

    public void OnButtonPressed()
    {
        displayText.text = "Hello, Welcome to Island!";
        backgroundImage.sprite = newBackgroundSprite;
    }

    private void Update()
    {
    }
}
