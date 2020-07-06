using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyNotifications : MonoBehaviour
{
    public static Texture texture;
    public static float timer = 0.0f;
    public static GUIStyle sTextStyle;
    public static Vector2 notificationSize;
    public static Vector2 startingPosition;
    public static Vector2 wantedPosition;
    public static Vector2 currentPos;
    public static AudioSource audioSource;
    private static Vector3 velocity3;
    private static bool callNotification = false;
    private static string message;

    public Texture notificationTexture;
    public GUIStyle textStyle;
    public Vector2 startingPos, endPos, size;
    public AudioSource notificationSound;

    void Awake()
    {
        audioSource = notificationSound;
        startingPosition = startingPos;
        wantedPosition = endPos;
        notificationSize = size;
        currentPos = startingPosition;
        texture = notificationTexture;
        sTextStyle = textStyle;
    }

    private static bool pushNotification(string _message, float _duration)
    {
        if (timer <= 0)
        {
            timer = _duration;
            if (audioSource != null)
                audioSource.Play();
        }
        else
        {
            if (timer < 1)
                currentPos = Vector3.SmoothDamp(currentPos, startingPosition, ref velocity3, 0.35f);
            else
                currentPos = Vector3.SmoothDamp(currentPos, wantedPosition, ref velocity3, 0.35f);

            GUI.DrawTexture(new Rect(currentPos.x, currentPos.y, notificationSize.x, notificationSize.y), texture);
            GUI.Box(new Rect(currentPos.x, currentPos.y, notificationSize.x, notificationSize.y), _message.ToString(), sTextStyle);

            timer -= 0.5f * Time.deltaTime;
            if (timer <= 0)
            {
                notifications.RemoveAt(0);
                times.RemoveAt(0);
                if (notifications.Count == 0)
                {
                    //print ("ne zovem");
                    return false;
                }
                else
                {
                    //print("zovem ponovno");
                    CallAgain();
                }
            }
            return true;
        }
        return true;
    }

    private static List<string> notifications = new List<string>();
    private static List<float> times = new List<float>();

    public static void CallNotification(string _message, float _duration)
    {
        notifications.Add(_message);
        times.Add(_duration);

        if (callNotification == false)
            callNotification = pushNotification(notifications[0], times[0]);
    }

    private static void CallAgain()
    {
        if (notifications.Count != 0)
        {
            callNotification = pushNotification(notifications[0], times[0]);
        }
    }

    void OnGUI()
    {
        if (callNotification)
        {
            callNotification = pushNotification(notifications[0], times[0]);
        }
    }
}