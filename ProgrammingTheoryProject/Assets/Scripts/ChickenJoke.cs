using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenJoke : MonoBehaviour
{
    [SerializeField] List<string> jokes = new List<string>();

    public string Joke
    {
        get { return SelectJoke(); }
    }

    private string SelectJoke()
    {
        int index = Random.Range(0, jokes.Count - 1);
        return jokes[index];

    }
}
