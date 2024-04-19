using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraManager : MonoBehaviour
{

    public float duration;
    [SerializeField] GameObject Currentcamera;
    [SerializeField] GameObject NextCame;


    void Start()
    {
        StartCoroutine(ActiveNextCamera());
    }

    IEnumerator ActiveNextCamera()
    {
        yield return new WaitForSeconds(duration);
        ActivateCamera();
    }

    void ActivateCamera()
    {
        if(Currentcamera.activeSelf){
        //Currentcamera.SetActive(false);
        NextCame.SetActive(true);
        }
    }
}
