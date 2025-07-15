using System;
using UnityEngine;

public class RecogerBala : MonoBehaviour
{
    public Transform puntoMira; // Punto donde se ancla la bala (hijo de la cámara)
    private GameObject balaSujeta;

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
    }

    private void OnTriggerEnter(Collider otro)
    {
        Debug.Log("Si colisiona");
        if (otro.CompareTag("Cañon"))
        {
            otro.GetComponent<BaseObjtosInreactuables>().CargarCañon();
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
