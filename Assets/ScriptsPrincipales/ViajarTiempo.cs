using UnityEngine;

public class TimeSwitcher : MonoBehaviour
{
    [Header("Configuración de Tiempo")]
    public GameObject pasado;
    public GameObject futuro;
    private bool enPasado = true;

    [Header("Configuración de Rotación")]
    public Transform cameraTransform;
    public float alturaFija = 1.5f;
    public float distanciaFrontal = 1.0f;

    private Vector3 initialRotation; // Rotación inicial del objeto (X y Z definidos en el Inspector)

    void Start()
    {
        // Guarda la rotación inicial del objeto (para mantener inclinaciones personalizadas)
        initialRotation = transform.eulerAngles;
        ActualizarTiempo();
    }

    void LateUpdate()
    {
        // 1. Posición: frente al jugador (con altura fija)
        Vector3 direccionHorizontal = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
        Vector3 nuevaPosicion = cameraTransform.position + (direccionHorizontal * distanciaFrontal);
        nuevaPosicion.y = cameraTransform.position.y + alturaFija;
        transform.position = nuevaPosicion;

        // 2. Rotación: 
        // - Mantiene X y Z iniciales (del Inspector)
        // - Solo actualiza el eje Y para mirar hacia la cámara
        Vector3 rotacionActual = transform.eulerAngles;
        Vector3 rotacionCamaraY = cameraTransform.eulerAngles;
        transform.eulerAngles = new Vector3(
            initialRotation.x,      // Mantén tu rotación X inicial
            rotacionCamaraY.y,     // Sincroniza solo el eje Y con la cámara
            initialRotation.z      // Mantén tu rotación Z inicial
        );
    }

    public void OnPointerClickXR() => CambiarTiempo();

    private void CambiarTiempo()
    {
        enPasado = !enPasado;
        ActualizarTiempo();
    }

    private void ActualizarTiempo()
    {
        pasado.SetActive(enPasado);
        futuro.SetActive(!enPasado);
    }
}