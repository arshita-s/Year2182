using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningNotification : MonoBehaviour
{
    public void playWarning()
    {
        NotificationManager.Instance.setNewNotification("You cannot travel beyond this point");
    }
}