using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource Audio;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    public void AddSource(AudioSource audio)
    {
        Audio = audio;
    }
    // Update is called once per frame
    void Update()
    {
        if (!Audio.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
