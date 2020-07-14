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
        Debug.Log("waitsecStart");
        yield return new WaitForSeconds(20);
        Debug.Log("Continue");
        uiObject.SetActive(false);
        // Destroy(gameObject);
    }
    
}