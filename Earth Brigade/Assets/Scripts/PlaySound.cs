using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public float delay = 1;
    public float fadeInTime = 1;
    float timeAccumulator = 0;
    float originalVolume = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Play", delay);
        originalVolume = GetComponent<AudioSource>().volume;
    }

    void Play()
    {
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        timeAccumulator += Time.deltaTime;
        GetComponent<AudioSource>().volume = originalVolume * Mathf.Clamp01((timeAccumulator - delay) / fadeInTime);
    }
}
