using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
 
    [SerializeField] private float jumpForce;

    private NavMeshAgent agentChicken;

    // Start is called before the first frame update
    void Start()
    {
        agentChicken = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    //left click
        {
            // ABSTRACTION

            MoveToClickedSpot();
        }

    }

    private void MoveToClickedSpot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50))
        {
            agentChicken.destination = hit.point;
        }

    }
}
