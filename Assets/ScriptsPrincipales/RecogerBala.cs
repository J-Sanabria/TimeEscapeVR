using System;
using UnityEngine;

public class RecogerBala : MonoBehaviour
{
    public Transform puntoMira; // Punto donde se ancla la bala (hijo de la cámara)
    private GameObject balaSujeta;

    // 🔹 Nuevo: Objeto que desaparecerá al recoger la bala
    public GameObject objetoADesaparecer;

    void Update()
    {
        if (balaSujeta != null)
        {
            balaSujeta.transform.position = puntoMira.position;
            balaSujeta.transform.rotation = puntoMira.rotation;
        }
    }

    public void OnPointerClickXR()
    {
        if (balaSujeta == null)
        {
            Recoger();
        }
    }

    private void Recoger()
    {
        balaSujeta = gameObject;

        // 🔹 Si hay un objeto asignado, lo desactivamos
        if (objetoADesaparecer != null)
        {
            objetoADesaparecer.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider otro)
    {
        Debug.Log("Si colisiona");
        if (otro.CompareTag("Ca�on"))
        {
            // otro.GetComponent<BaseObjtosInreactuables>().CargarCa�on();
            DesaparecerBala();
        }
    }

    private void DesaparecerBala()
    {
        if (balaSujeta != null)
        {
            balaSujeta = null;
            gameObject.SetActive(false);
        }
    }
}
