using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    /*public GameObject lastHit;
    public Vector3 collision = Vector3.zero;
    public LayerMask layer;
    public GameObject player;
    public GameObject desiredPosObj;
    Vector3 desiredPos;
    private float newPos;
    private float wallOffset = 0.8f;
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = desiredPosObj.transform.position;                                  // if doesnt work, try other way of tracking ...pos and ...posobj
        var ray = new Ray(player.transform.position, desiredPosObj.transform.position);          // reverse if it doesnt work
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f, layer))
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;
            newPos = hit.distance;
            targetPosition = (collision - player.transform.position) * wallOffset + player.transform.position;
        }
        else
        {
            targetPosition = desiredPos;             
        }
    }
    */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }
    

    public GameObject Origin;
    public GameObject Target;
    public GameObject Cam;
    public float CamRange = 5f;
    public Vector3 collision;
    public float wallOffset;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 Direction = Origin.transform.position - Target.transform.position;
        Direction = Direction.normalized;
        var ray = new Ray(Origin.transform.position, Direction);
        if (Physics.Raycast(ray, out RaycastHit hit, CamRange))
        {
            Cam.transform.position = hit.point;
            collision = hit.point - Cam.transform.position;
        }
        else
        {
            Cam.transform.position = Origin.transform.position;
        }

    }



}


























