using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioInicio;
    private bool AudioEnReproduccion = false;// Clip de sonido que se reproducirá al iniciar la escena

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            AudioEnReproduccion = true;
            Invoke("VolverAReposo", audioInicio.length);
        }
    }

    private void Start()
    {
        if (audioInicio != null)
        {
            audioSource.PlayOneShot(audioInicio);
        }
    }

    public void ReproducirSonido(AudioClip clip)
    {
        if (clip != null)
        {
            if(AudioEnReproduccion == true)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(clip);
                AudioEnReproduccion = true;
            } else
            {
                audioSource.PlayOneShot(clip);
                AudioEnReproduccion = true;
            }
         
        }
    }

    public void Pausar()
    {
        audioSource.Stop();
        AudioEnReproduccion = false;
    }
}
