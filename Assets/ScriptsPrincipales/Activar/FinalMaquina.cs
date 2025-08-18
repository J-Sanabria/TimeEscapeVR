using UnityEngine;

public class FinalMaquina : MonoBehaviour
{
    [Header("Animación del objeto actual")]
    public Animation animObjeto;          // Animación en este objeto
    public string nombreAnimObjeto;       // Nombre de la animación que debe reproducirse

    [Header("Personaje")]
    public GazeAnimationController personaje;  // Script del personaje
    public AudioClip AudioClipInicio;          // Audio del personaje
    private bool AudioActivado = false;

    [Header("Objetos a controlar")]
    public GameObject objetoA;
    public GameObject Reloj;         // Se oculta inmediatamente al clic
    public GameObject objetoB;        // Se oculta solo al terminar animación + audio
    public GameObject objetoFinal;    // Objeto que aparecerá al final

    public float delayExtra = 0.5f;   // Pequeño retraso después del audio/animación

    public void OnPointerClickXR()
    {
        if (!AudioActivado && personaje != null && AudioClipInicio != null)
        {
            // 1. Activar animación en este objeto
            if (animObjeto != null && !string.IsNullOrEmpty(nombreAnimObjeto))
            {
                animObjeto.Play(nombreAnimObjeto);
            }

            // 2. Activar personaje con su animación + audio
            personaje.ActivarDesdeOtroObjeto(AudioClipInicio);

            // 3. Marcar que ya se activó
            AudioActivado = true;

            // 4. Ocultar inmediatamente Objeto A
            if (objetoA != null)
            {
                objetoA.SetActive(false);
            }

             if (Reloj != null)
            {
                Reloj.SetActive(false);
            }

            // 5. Calcular tiempo de espera (máximo entre animación y audio)
            float tiempoAnimObjeto = (animObjeto != null && animObjeto[nombreAnimObjeto] != null) 
                ? animObjeto[nombreAnimObjeto].length 
                : 0f;

            float tiempoAudio = AudioClipInicio.length;
            float tiempoMax = Mathf.Max(tiempoAnimObjeto, tiempoAudio);

            // 6. Ocultar Objeto B y activar el objetoFinal después del tiempo
            Invoke(nameof(AccionesFinales), tiempoMax + delayExtra);
        }
    }

    private void AccionesFinales()
    {
        // Ocultar Objeto B
        if (objetoB != null)
        {
            objetoB.SetActive(false);
        }

        // Activar el objeto final
        if (objetoFinal != null)
        {
            objetoFinal.SetActive(true);
        }
    }
}
