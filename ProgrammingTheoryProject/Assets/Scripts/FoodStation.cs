using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStation : MonoBehaviour
{
    [SerializeField] private int servingSize;
    [SerializeField] private Food food;
    [SerializeField] private Chicken chicken;

    private void Update()
    {
        if (chicken.IsHungry)
        {
            Dispense(food);
            // Feed the chicken according to the serving size
        }
        else
        {

        }
    }

    // POLYMORPHISM (OVERLOAD)
    private void Dispense(Food food)
    {

    }

    private void Dispense(ChickenJoke joke)
    {

    }
}
