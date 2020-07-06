using UnityEngine;
using UnityEngine.UI;

public class CarbonBar : MonoBehaviour
{
    [Tooltip("Slider component displaying carbon amount")]
    public Slider CarbonSlider;

    CarbonAccount carbon;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacterController playerCharacterController = GameObject.FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, CarbonBar>(playerCharacterController, this);

        carbon = playerCharacterController.GetComponent<CarbonAccount>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, CarbonBar>(carbon, this, playerCharacterController.gameObject);

        CarbonSlider.value = carbon.CalculateCarbonProportion();
    }

    // Update is called once per frame
    void Update()
    {
        CarbonSlider.value = carbon.CalculateCarbonProportion();
    }
}
