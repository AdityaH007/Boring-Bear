using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void vsetolume(float volume)
    {
       // Debug.Log(volume);
        audiomixer.SetFloat("Volume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        switch (resolutionIndex)
        {
            case 0:
                Screen.SetResolution(1920, 1080,true); // 1080p
                break;
            case 1:
                Screen.SetResolution(1280, 720, true); // 720p
                break;
            case 2:
                Screen.SetResolution(3840, 2160, true); // 4K
                break;
            default:
                Debug.LogWarning("Invalid resolution index");
                break;
        }

    }
}
