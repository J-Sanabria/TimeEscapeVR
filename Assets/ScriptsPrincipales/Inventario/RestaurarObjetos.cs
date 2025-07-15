using UnityEngine;

public class RestaurarObjetos : MonoBehaviour
{
    public GameObject artefacto01;
    public GameObject artefacto02;
    public GameObject artefacto03;
    public GameObject artefacto04;
    public GameObject Premio;
    public GameObject Puerta;

    private void Start()
    {
        if (InventarioManager.Instance.Artefacto01) artefacto01.SetActive(true);
        if (InventarioManager.Instance.Artefacto02) artefacto02.SetActive(true);
        if (InventarioManager.Instance.Artefacto03) artefacto03.SetActive(true);
        if (InventarioManager.Instance.Artefacto04) artefacto04.SetActive(true);

        int cantidadArtefactos = InventarioManager.Instance.CantidadArtefactos;
        if (cantidadArtefactos == 4)
        {
            Premio.SetActive(true);
            Puerta.SetActive(true);
        }
    }
}
