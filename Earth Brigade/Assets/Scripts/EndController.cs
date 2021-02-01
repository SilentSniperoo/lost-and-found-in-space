using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public Sprite[] playerSpriteArray;

    // Start is called before the first frame update
    void Start()
    {
        Image image = this.GetComponent<Image>();

        if (ScoreStatus.Score < 4)
        {
            image.sprite = playerSpriteArray[0];
        }
        else if (ScoreStatus.Score < 8)
        {
            image.sprite = playerSpriteArray[1];
        }
        else
        {
            image.sprite = playerSpriteArray[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }
}
