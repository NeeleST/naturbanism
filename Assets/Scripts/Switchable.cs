using UnityEngine;
using System.Collections.Generic;

public class Switchable : MonoBehaviour
{
    public void SwitchTo(GameObject to)
    {
        var a = Instantiate(to, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
