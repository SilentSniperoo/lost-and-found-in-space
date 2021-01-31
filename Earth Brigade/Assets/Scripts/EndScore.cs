using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Sprite[] digits = new Sprite[10];

    public Image tensSecondsImage;
    public Image onesSecondsImage;

    // Start is called before the first frame update
    void Start()
    {
        tensSecondsImage.sprite = digits[Mathf.Clamp(ScoreStatus.Score / 10, 0, 9)];
        onesSecondsImage.sprite = digits[Mathf.Clamp(ScoreStatus.Score % 10, 0, 9)];
    }
}
