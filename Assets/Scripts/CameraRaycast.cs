using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public GameObject lastHit;
    public Vector3 collision = Vector3.zero;
    public LayerMask layer;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);          // reverse if it doesnt work
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layer))
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;
            
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }


}
