using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    
    public static NotificationManager Instance
    {
        get
        {
            if(instance != null)
            {
                return instance;
            }
            instance = FindObjectOfType<NotificationManager>();

            if (instance != null)
            {
                return instance;
            }
            CreateNewInstance();
            return instance;
        }
    }
    public static NotificationManager CreateNewInstance()
    {
        NotificationManager notificationManagerPrefab = Resources.Load<NotificationManager>("NotificationManager");
        instance = Instantiate(notificationManagerPrefab);
        return instance;
    }

    private static NotificationManager instance;
    private void Awake()
    {
        if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float fadeTime;

    private IEnumerator notificationCoroutine;

    public void setNewNotification(string message)
    {
        if(notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }
        notificationCoroutine = FadeOutNotification(message);
        StartCoroutine(notificationCoroutine);
    }

    private IEnumerator FadeOutNotification(string message)
    {
        text.text = message;
        float t = 0;
        while(t < fadeTime)
        {
            t += Time.unscaledDeltaTime;
            text.color = new Color(text.color.r, text.color.g, text.color.b, Mathf.Lerp(1f, 0f, t / fadeTime));
            yield return null;
        }
    }
    
}
