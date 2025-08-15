using UnityEngine;

public class ActivadorAudio : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip audioClip;
    [Tooltip("Si está activado, el audio solo se reproducirá una vez.")]
    public bool reproducirUnaVez = false;

    private bool yaReproducido = false;

    public void OnPointerClickXR()
    {
        if (audioManager != null && audioClip != null)
        {
            if (reproducirUnaVez)
            {
                if (!yaReproducido)
                {
                    audioManager.ReproducirSonido(audioClip);
                    yaReproducido = true;
                }
            }
            else
            {
                audioManager.ReproducirSonido(audioClip);
            }
        }
        else
        {
            Debug.LogWarning("Falta asignar el AudioManager o el AudioClip en " + gameObject.name);
        }
    }
}
