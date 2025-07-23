using UnityEngine;

public class ActivadorAudio : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip audioClip;

    public void OnPointerClickXR()
    {
        if (audioManager != null && audioClip != null)
        {
            audioManager.ReproducirSonido(audioClip);
        }
        else
        {
            Debug.LogWarning("Falta asignar el AudioManager o el AudioClip en " + gameObject.name);
        }
    }
}
