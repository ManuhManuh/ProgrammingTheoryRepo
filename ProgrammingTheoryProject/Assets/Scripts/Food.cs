using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // ENCAPSULATION
    public int FoodValue
    {
        get { return foodValue; }
    }

    [SerializeField] protected int foodValue;
}
