using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaGaze : MonoBehaviour
{
    [SerializeField] private string escenaDestino = "EscenaPrueba01"; // Nombre de la escena a cargar

    public void OnPointerClickXR()
    {
        // Si la escena actual es "Tutorial", solo cambia la escena sin modificar el inventario
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            CambiarEscena();
            return;
        }

        // Si no es "Tutorial", modificar el inventario como antes
        if (!InventarioManager.Instance.Inicio)
            InventarioManager.Instance.Inicio = true;

        CambiarEscena();
    }

    private void CambiarEscena()
    {
        SceneManager.LoadScene(escenaDestino);
    }
}
