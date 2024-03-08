using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMove : MonoBehaviour
{
    public Camera cam;
    private RaycastHit hit;
    private NavMeshAgent agent;
    //
    Rigidbody playerrb;
    public float movementspeed = 7;
    public float rotationspeed = 15;
    //
    private string GroundTag = "Ground";
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerrb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.CompareTag(GroundTag))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
