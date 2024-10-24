using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    int CDs = 0;

    [SerializeField] TextMeshProUGUI cdsText;
    [SerializeField] AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CD"))
        {
            Destroy(other.gameObject);
            CDs++;
            cdsText.text = "CD's Collected: " + CDs;
        }
    }
}
