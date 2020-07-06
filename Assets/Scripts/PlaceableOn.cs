using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableOn : MonoBehaviour
{
    public void Place(GameObject obj, Vector3 point, Vector3 normal) {
        Instantiate(obj, point, Quaternion.FromToRotation(Vector3.up, normal));
    }
}
