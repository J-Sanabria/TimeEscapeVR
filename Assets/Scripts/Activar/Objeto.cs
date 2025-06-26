using UnityEngine;

public class ObjetoAnimado : MonoBehaviour
{
    public Animation animador; // Componente Animation
    public string nombreAnimacion;
    public bool yaSeAnimo = false;// Nombre de la animaci�n a reproducir

    public void ActivarDesdeOtroObjeto()
    {
        if (animador != null && yaSeAnimo == false)
        {
            animador.Play(nombreAnimacion); // Reproduce la animaci�n especificada
            yaSeAnimo = true;
        }
    }
}
