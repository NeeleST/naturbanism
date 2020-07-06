using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	void Awake(){
		StartCoroutine("moja");
	}
	IEnumerator moja(){
		yield return new WaitForSeconds(1);
		
		MyNotifications.CallNotification("Welcome to the Game", 2);
		MyNotifications.CallNotification("Um die welt ist es schlecht bestellt. Der Klimawandel bedroht uns alle!", 4);
		MyNotifications.CallNotification("Zeit zu handeln!", 3);
	}
}
