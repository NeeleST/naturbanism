using UnityEngine;
using UnityEngine.UI;

public class ScoreBars : MonoBehaviour
{
    [Tooltip("Slider component displaying carbon amount")]
    public Slider CarbonSlider;

    [Tooltip("Slider component displaying biodiversity amount")]
    public Slider BiodiversitySlider;

    [Tooltip("Slider component displaying food amount")]
    public Slider FoodSlider;

    [Tooltip("Slider component displaying energy amount")]
    public Slider EnergySlider;

    PlayerScores scores;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, ScoreBars>(playerCharacterController, this);

        scores = playerCharacterController.GetComponent<PlayerScores>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerScores, ScoreBars>(scores, this, playerCharacterController.gameObject);

        CarbonSlider.value = scores.CalculateProportion(Scores.Carbon);
        BiodiversitySlider.value = scores.CalculateProportion(Scores.Biodiversity);
        FoodSlider.value = scores.CalculateProportion(Scores.Food);
        EnergySlider.value = scores.CalculateProportion(Scores.Energy);
    }

    // Update is called once per frame
    void Update()
    {
        CarbonSlider.value = scores.CalculateProportion(Scores.Carbon);
        BiodiversitySlider.value = scores.CalculateProportion(Scores.Biodiversity);
        FoodSlider.value = scores.CalculateProportion(Scores.Food);
        EnergySlider.value = scores.CalculateProportion(Scores.Energy);
    }
}
