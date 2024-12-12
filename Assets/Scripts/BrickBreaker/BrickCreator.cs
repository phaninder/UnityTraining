using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject brickPrefab;
    [SerializeField]
    private Vector3 startPosition;
    [SerializeField]
    private int numOfBrick = 10;
    [SerializeField]
    private int colCount = 5;
    // Start is called before the first frame update
    void Start()
    {
        startPosition.x = GameData.ScreenStartPosition.x + 2;
        float screenEndPos = GameData.ScreenEndPosition.x - 2;
        for (int i = 0, col = 0; i < numOfBrick; i++, col++)
        {
            var brickPos = startPosition;
            brickPos.x += col * 3; // -12 + 1*3 =  -9

            if(brickPos.x >= screenEndPos || col >= colCount)
            {
                startPosition.y -= 2;
                brickPos = startPosition;
                col = 0;
            }
            Instantiate(brickPrefab, brickPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
