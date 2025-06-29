using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportPoint : MonoBehaviour
{
    public UnityEvent OnTeleportEnter;
    public UnityEvent OnTeleport;
    public UnityEvent OnTeleportExit;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnPointerEnterXR()
    {
        OnTeleportEnter?.Invoke();
    }

    public void OnPointerClickXR()
    {
        ExecuteTeleportation();
        OnTeleport?.Invoke();
        TeleportManager.Instance.DisableTeleportPoint(gameObject);
    }

    public void OnPointerExitXR()
    {
        OnTeleportExit?.Invoke();
    }

    private void ExecuteTeleportation()
    {
        GameObject player = TeleportManager.Instance.Player;

        // Guarda la rotaci�n actual en Y
        float currentYRotation = player.transform.eulerAngles.y;

        // Teletransporta al jugador
        player.transform.position = transform.position;

        // Restaura su rotaci�n original en Y
        player.transform.rotation = Quaternion.Euler(0f, currentYRotation, 0f);
    }
}

