using UnityEngine;
using System.Collections.Generic;

public class Switchable : MonoBehaviour
{
    [Tooltip("Is this object special about its transform and rotation, because... reasons?")]
    public bool isSpecial = false;

    public void SwitchTo(GameObject to, Vector3 point, Vector3 normal)
    {
        if (isSpecial) {
            point.y = 0f; // clamp to ground
            Instantiate(to, point, Quaternion.identity); // assume new object is standing up
        } else {
            Instantiate(to, gameObject.transform.position, gameObject.transform.rotation);
        }
        Destroy(gameObject);
    }
}
