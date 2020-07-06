using UnityEngine;
using UnityEngine.UI;

/*
 * CarbonAccount keeps track of the current amount of carbon for the player
 */
public class CarbonAccount : MonoBehaviour
{
    public float CurrentCarbon { get; set; }
    public float MaxCarbon;

    // public Text CarbonText;

    void Start()
    {
        CurrentCarbon = MaxCarbon;
        Debug.Log("Carbon start: " + CurrentCarbon);
    }

    void Update()
    {
        // CarbonText.text = "Carbon captured: " + CurrentCarbon + " tCO2 / year";
    }

    public void AddCarbon(float value)
    {
        CurrentCarbon += value;
        Debug.Log("Carbon: " + CurrentCarbon);
    }

    public void RemoveCarbon(float value)
    {
        CurrentCarbon -= value;
        Debug.Log("Carbon: " + CurrentCarbon);
    }

    public float CalculateCarbonProportion()
    {
        return CurrentCarbon / MaxCarbon;
    }
}
