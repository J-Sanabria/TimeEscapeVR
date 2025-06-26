using UnityEngine;

public class MaquinaDelTiempo: MonoBehaviour
{
    public GazeAnimationController personaje;
    public AudioClip Incio;
    public AudioClip Artefacto01;
    public AudioClip Artefacto02;
    public AudioClip Artefacto03;
    public AudioClip Win; // Asigna en el Inspector el clip que debe activar

    public void OnPointerClickXR()

    {
        int cantidadArtefactos = InventarioManager.Instance.CantidadArtefactos;
        
        if (personaje != null && Incio != null && cantidadArtefactos == 0)
        {
            personaje.ActivarDesdeOtroObjeto(Incio);
        }
       

        if (cantidadArtefactos == 1 && !InventarioManager.Instance.Artefacto01Activado && Artefacto01 != null)
        {
            personaje.ActivarDesdeOtroObjeto(Artefacto01);
            InventarioManager.Instance.Artefacto01Activado = true;
        }

        if (cantidadArtefactos == 2 && !InventarioManager.Instance.Artefacto02Activado && Artefacto02 != null)
        {
            personaje.ActivarDesdeOtroObjeto(Artefacto02);
            InventarioManager.Instance.Artefacto02Activado = true;
        }

        if (cantidadArtefactos == 3 && !InventarioManager.Instance.Artefacto03Activado && Artefacto03 != null)
        {
            personaje.ActivarDesdeOtroObjeto(Artefacto03);
            InventarioManager.Instance.Artefacto03Activado = true;
        }


        if (personaje != null && Win != null && cantidadArtefactos == 4)
        {
            personaje.ActivarDesdeOtroObjeto(Win);
            InventarioManager.Instance.Win = true;
        }
    }
}