using UnityEngine;

public class ActivadorAudio : MonoBehaviour
{
    public AudioManager audioManager; // Referencia directa al AudioManager
    public AudioClip audioClip;
    private bool AudioActivado = false; 

    public void OnPointerClickXR()
    {
        if (audioManager != null && audioClip != null && AudioActivado == false)
        {
            audioManager.ReproducirSonido(audioClip);
            AudioActivado = true;
        }
        else
        {
            Debug.LogWarning("Falta asignar el AudioManager o el AudioClip en " + gameObject.name);
        }
    }
}
