using UnityEngine;

public class ActivarAnimacion : MonoBehaviour
{
    public ObjetoAnimado objetoAnimado; // Referencia al script del objeto animado

    public void OnPointerClickXR()
    {
        if (objetoAnimado != null)
        {
            objetoAnimado.ActivarDesdeOtroObjeto(); // Activa la animación del otro objeto
        }
    }
}
