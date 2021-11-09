using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodStation : MonoBehaviour
{
    [SerializeField] private Food food;
    [SerializeField] private ChickenJoke chickenJokePrefab;
    [SerializeField] private Chicken chicken;
    [SerializeField] private Vector3 foodOffset;
    [SerializeField] private TMP_Text chickenJokeText;

    private bool chickenIsClose;
    private bool foodDispensed;

    private void Update()
    {
        if (chickenIsClose && !foodDispensed)
        {
            foodDispensed = true;

            if (chicken.IsHungry)
            {
                // Toss the food out so the chicken can eat it
                Dispense(food);
                
            }
            else
            {
                 // Display a random chicken joke in the UI
                ChickenJoke chickenJoke = Instantiate(chickenJokePrefab);
                Dispense(chickenJoke);
            }
        }

        // TESTING
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //Dispense(chickenJokePrefab);
        }
    }

    // POLYMORPHISM (OVERLOAD)
    private void Dispense(Food foodPrefab)
    {

        Instantiate(foodPrefab, transform.position + foodOffset, transform.rotation);
    }

    private void Dispense(ChickenJoke chickenJokePrefab)
    {

        chickenJokeText.text = chickenJokePrefab.Joke;
    }
}
