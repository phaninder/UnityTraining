using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    [SerializeField]
    private Transform nextObject;
    [SerializeField]
    private float xPosDelta;
    [SerializeField]
    private ObjectMovement objectMovementRef;

    // Start is called before the first frame update
    void Start()
    {
        //xPosDelta = Mathf.Abs(nextObject.position.x - transform.position.x);
        if(objectMovementRef == null)
        {
            objectMovementRef = nextObject.GetComponent<ObjectMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < GameData.ScreenStartPosition.x)
        {
            var newPos = objectMovementRef.GetNextUpdatePosition();
            Debug.Log($"Next pos X{newPos.x}");
            newPos.x = nextObject.position.x + xPosDelta; // 30 -> 9
            Debug.Log($"Pos to set in x:{newPos.x}");
            transform.position = newPos;
        }
    }
}
