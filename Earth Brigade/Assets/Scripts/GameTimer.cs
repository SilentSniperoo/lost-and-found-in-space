using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Sprite[] digits = new Sprite[10];
    public Image onesMinutesImage;
    public Image tensSecondsImage;
    public Image onesSecondsImage;

    [Range(0, 9)]
    public int minutes = 3;
    [Range(0, 59)]
    public int seconds = 0;

    float timeAccumulator = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateTimerSprites();
    }

    // Update is called once per frame
    void Update()
    {
        timeAccumulator += Time.deltaTime;
        seconds -= (int)timeAccumulator;
        timeAccumulator %= 1;
        if (seconds < 0)
        {
            seconds *= -1;
            minutes -= 1 + seconds / 60;
            seconds %= 60;
            seconds = 60 - seconds;
        }
        if (minutes < 0)
        {
            minutes = 0;
            seconds = 0;
        }

        updateTimerSprites();
    }

    void updateTimerSprites()
    {
        onesMinutesImage.sprite = digits[Mathf.Clamp(minutes, 0, 9)];
        tensSecondsImage.sprite = digits[Mathf.Clamp(seconds / 10, 0, 9)];
        onesSecondsImage.sprite = digits[Mathf.Clamp(seconds % 10, 0, 9)];
    }
}
