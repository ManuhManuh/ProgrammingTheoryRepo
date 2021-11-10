using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    

    [SerializeField] private List<Egg> eggs = new List<Egg>();
    [SerializeField] private TMP_Text winCheckText;
    private Egg winningEgg;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        // Generate the winning egg type

        int index = Random.Range(0, eggs.Count);
        winningEgg = eggs[index];
        //Debug.Log($"The winning egg type is {winningEgg.GetType()}");
    }

    public bool IsWinningType(Egg laidEgg)
    {
        return laidEgg.GetType() == winningEgg.GetType();
    }

    public void CheckForWin(Egg laidEgg)
    {
        if (IsWinningType(laidEgg))
        {
            winCheckText.text = "You laid the winning egg type - congratulations!!";
            
        }
        else
        {
            winCheckText.text = "You laid the wrong egg type - cry in shame!!";
        }

        // TODO: Add replay button
    }

}
