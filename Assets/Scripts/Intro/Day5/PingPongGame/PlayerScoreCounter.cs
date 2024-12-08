using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreCounter : MonoBehaviour
{
    [SerializeField]
    private int score = 0;

    public void IncreaseScore()
    {
        score++;
        Debug.Log($"{gameObject.name} : {score}");
    }
}
