using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Vector2 direction = new Vector2(1, 0);
    public float leftSideMinPosition, rightSideMaxPosition;

    // Start is called before the first frame update
    void Start()
    {      
        var collider = GetComponent<BoxCollider2D>();
        
        leftSideMinPosition = GameData.ScreenStartPosition.x + (collider.size.x / 2);
        rightSideMaxPosition = GameData.ScreenEndPosition.x - (collider.size.x / 2);
    }

    // Update is called once per frame
    void Update()
    {

        var val = Input.GetAxis("Horizontal");
        transform.Translate(direction * val * moveSpeed * Time.deltaTime);


        var position = transform.position;

        if (position.x < leftSideMinPosition)
        {
            position.x = leftSideMinPosition;
            transform.position = position;
        }
        else if(position.x > rightSideMaxPosition)
        {
            position.x = rightSideMaxPosition;
            transform.position = position;
        }
    }
}
