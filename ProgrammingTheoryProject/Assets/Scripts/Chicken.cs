using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    public int cholocateCount;
    public int pepperCount;
    public int seedCount;

    public bool IsHungry
    {
        get { return isHungry; }
        set { isHungry = value; }
    }
    private bool isHungry;

    private bool onNest;

    [SerializeField] private float jumpForce;

    private NavMeshAgent agentChicken;

    // Start is called before the first frame update
    void Start()
    {
        agentChicken = GetComponent<NavMeshAgent>();
        cholocateCount = 0;
        pepperCount = 0;
        seedCount = 0;
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

    private void Eat(Food food)
    {
        
    }

    private void LayEgg(HardBoiled egg)
    {

    }

    private void LayEgg(EasterCream egg)
    {

    }

    private void LayEgg(ChickToBe egg)
    {

    }
}
