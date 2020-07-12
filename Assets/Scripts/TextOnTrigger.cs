using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnTrigger : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }
	// Update is called once per frame
	void OnTriggerEnter (Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
	}
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(30);
        uiObject.SetActive(false);
        // Destroy(gameObject);
    }
    
}
