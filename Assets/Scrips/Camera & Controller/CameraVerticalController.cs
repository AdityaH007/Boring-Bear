using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticalController : MonoBehaviour
{

    public float movespeed = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput =Input.GetAxis("Vertical");
        Vector3 verticalMovement = new Vector3(0f, verticalInput * movespeed * Time.deltaTime, 0f);

        transform.Translate(verticalMovement);

    }
}
