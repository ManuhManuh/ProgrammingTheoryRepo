using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    
    // ENCAPSULATION
    public bool IsHungry
    {
        get { return isHungry; }
        set { isHungry = value; }
    }
    private bool isHungry;

    [SerializeField] private int maxFoodValue;
    [SerializeField] private Nest nest;
    [SerializeField] private EasterCream easterCreamPrefab;
    [SerializeField] private HardBoiled hardBoildedPrefab;
    [SerializeField] private ChickToBe chickToBePrefab;
    [SerializeField] private float eggOffset;

    private int cholocateCount;
    private int pepperCount;
    private int seedCount;
    private int totalFood;
    private bool eggLaid;
   

    private NavMeshAgent agentChicken;

    // Start is called before the first frame update
    void Start()
    {
        agentChicken = GetComponent<NavMeshAgent>();
        cholocateCount = 0;
        pepperCount = 0;
        seedCount = 0;
        totalFood = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    //left click
        {
            // ABSTRACTION

            MoveToClickedSpot();
        }

        if (nest.Occupied && !eggLaid)
        {
  
            InitiateLaying();
        }

        // TESTING

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Do whatever is being tested
           // agentChicken.SetDestination(nest.transform.position);

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

    private void Eat(Food food, int foodValue)
    {
        // local UI - "gulp"

        // Add food value to total, and to food type subtotal

        string foodType = food.GetType().ToString();

        switch (foodType)
        {
            case ("Chocolate"):
                {
                    cholocateCount += foodValue;
                    break;
                }

            case ("Peppers"):
                {
                    pepperCount += foodValue;
                    break;
                }
            case ("Seeds"):
                {
                    seedCount += foodValue;
                    break;
                }

        }

        totalFood += foodValue;
        
        if (totalFood >= maxFoodValue)
        {
            //set the chicken to not hungry
            isHungry = false;

            // go to the nest
            agentChicken.SetDestination(nest.transform.position);
        }

    }

    private void InitiateLaying()
    {
        eggLaid = true;

        if (cholocateCount > seedCount && cholocateCount > pepperCount)
        {
            StartCoroutine(LayEgg(easterCreamPrefab));
        }
        else if(seedCount > cholocateCount && seedCount > pepperCount)
        {
            StartCoroutine(LayEgg(chickToBePrefab));
        }
        else
        {
            StartCoroutine(LayEgg(hardBoildedPrefab));
        }

    }

    private IEnumerator LayEgg(Egg eggPrefab)
    {
        yield return new WaitForSeconds(2);
        Instantiate(eggPrefab,transform.position + new Vector3(eggOffset,0f,0f), transform.rotation);
    }
}
