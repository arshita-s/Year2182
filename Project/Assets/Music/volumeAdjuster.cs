using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumeAdjuster : MonoBehaviour
{
    public AudioMixer mixer;

    public void setLevel(float sliderValue)
    {
        mixer.SetFloat("musicVol", Mathf.Log10(sliderValue) * 20);
    }
}
