using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    public Sprite[] playerSpriteArray;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();

        if (ScoreStatus.Score < 4)
        {
            sr.sprite = playerSpriteArray[0];
        }
        else if (ScoreStatus.Score < 8)
        {
            sr.sprite = playerSpriteArray[1];
        }
        else
        {
            sr.sprite = playerSpriteArray[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
