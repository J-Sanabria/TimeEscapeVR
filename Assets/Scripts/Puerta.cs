using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaGaze : MonoBehaviour
{
    [SerializeField] private string escenaDestino = "EscenaPrueba01"; // Nombre de la escena a cargar

    public void OnPointerClickXR()
    {
        if (InventarioManager.Instance.Inicio == false)InventarioManager.Instance.Inicio = true;
        CambiarEscena();
    }

    private void CambiarEscena()
    {
        SceneManager.LoadScene(escenaDestino);
    }
}