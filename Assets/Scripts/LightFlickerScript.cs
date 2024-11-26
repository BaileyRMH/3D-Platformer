using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LightFlickerScript : MonoBehaviour
{
    Light myLight;


    void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        



        Invoke("LightOn", 2f);

        Invoke("LightOff", 5f);

    }

    public void LightOn()
    {

    }

    public void LightOff()
    {

    }



}
