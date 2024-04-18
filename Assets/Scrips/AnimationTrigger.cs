using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] GameObject triggerObject;
    public Animator animation;
    public string animationTriggerName;
    [SerializeField] AudioSource audio;

    void OnTriggerEnter(Collider other)
    {
        animation.SetTrigger(animationTriggerName);
        audio.Play();
        triggerObject.SetActive(false);
    }
}
