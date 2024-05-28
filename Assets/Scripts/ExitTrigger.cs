using System;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public static Action OnPlayerWin;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnPlayerWin?.Invoke();
        }
    }
}
