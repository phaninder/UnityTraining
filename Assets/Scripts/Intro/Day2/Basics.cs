using UnityEngine;

public class Basics : MonoBehaviour
{
    public string myName = "Basics";
    // Called once when object gets active
    private void Awake()
    {
        Debug.Log("From Awake");
    }

    // Gets called each time attached gameobject is enabled
    private void OnEnable()
    {
        Debug.Log("From OnEnable");
    }

    // Called once before Update 
    private void Start()
    {
        Debug.Log("From Start");
    }

    // Gets called each time attached gameobject is disabled
    private void OnDisable()
    {
        Debug.Log("From OnDisable");
    }

    //Gets called each frame
    private void Update()
    {
        Debug.Log("From Update");
    }

    // Call is dependent on fixed Timestamp 
    private void FixedUpdate()
    {
        Debug.Log("From FixedUpdate");
    }

    // Gets called each frame, but after update 
    private void LateUpdate()
    {
        Debug.Log("From LateUpdate");
    }
}
