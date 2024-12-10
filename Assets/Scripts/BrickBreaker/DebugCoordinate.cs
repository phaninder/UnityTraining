using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCoordinate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Screen Width:"+Screen.width +", Screen height:"+Screen.height);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    var screenPos = Camera.main.WorldToScreenPoint(transform.position);
    //    Debug.Log($"World pos: {transform.position}, Scree pos :{screenPos}");
    //}
}
