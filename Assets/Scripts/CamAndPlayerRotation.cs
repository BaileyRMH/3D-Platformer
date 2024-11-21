using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAndPlayerRotation : MonoBehaviour
{
    public float mousSens;
    public GameObject player;

    

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mousSens * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);


    }
}
