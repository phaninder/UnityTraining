using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPositionSetter : MonoBehaviour
{
    [SerializeField]
    private float yMin, yMax;

    private void OnEnable()
    {
        float yPos = Random.Range(yMin, yMax);
        Vector3 pos = transform.position;
        pos.y = yPos;
        transform.position = pos;
    }
}
