using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Adds the associated CarbonValue to the CarbonAccount on start
 */
public class ObjectScoreValues : MonoBehaviour
{
    private PlayerScores Account;
    public float CarbonValue;
    public float BiodiversityValue;
    public float FoodValue;
    public float EnergyValue;

    // Start is called before the first frame update
    void Start()
    {
        Account = FindObjectOfType<PlayerScores> ();
        Account.Add(Scores.Carbon, CarbonValue);
        Account.Add(Scores.Biodiversity, BiodiversityValue);
        Account.Add(Scores.Food, FoodValue);
        Account.Add(Scores.Energy, EnergyValue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Account.Remove(Scores.Carbon, CarbonValue);
        Account.Remove(Scores.Biodiversity, BiodiversityValue);
        Account.Remove(Scores.Food, FoodValue);
        Account.Remove(Scores.Energy, EnergyValue);
    }

}
