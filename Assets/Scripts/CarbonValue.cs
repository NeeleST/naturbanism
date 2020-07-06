using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Adds the associated CarbonValue to the CarbonAccount on start
 */
public class CarbonValue : MonoBehaviour
{
    private CarbonAccount Account;
    public float Value;

    // Start is called before the first frame update
    void Start()
    {
        Account = FindObjectOfType<CarbonAccount> ();
        Account.AddCarbon(Value);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        Account.RemoveCarbon(Value);
    }

}
