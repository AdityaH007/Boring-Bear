using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
 public float duration;

 [SerializeField] GameObject[] gameObject;

 void Start()
 {
    StartCoroutine(ActivateObject());
 }

 IEnumerator ActivateObject()
 {
    yield return new WaitForSeconds(duration);
            foreach (GameObject obj in gameObject)
        {
            obj.SetActive(true);
        }
 }
}
