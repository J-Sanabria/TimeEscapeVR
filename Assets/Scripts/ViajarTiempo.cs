using UnityEngine;

public class TimeSwitcher : MonoBehaviour
{
    [Header("Configuraci�n de Tiempo")]
    public GameObject pasado;
    public GameObject futuro;
    private bool enPasado = true;

    [Header("Configuraci�n de Rotaci�n")]
    public Transform cameraTransform;
    public float alturaFija = 1.5f;
    public float distanciaFrontal = 1.0f;

    private Vector3 initialRotation; // Rotaci�n inicial del objeto (X y Z definidos en el Inspector)

    void Start()
    {
        // Guarda la rotaci�n inicial del objeto (para mantener inclinaciones personalizadas)
        initialRotation = transform.eulerAngles;
        ActualizarTiempo();
    }

    void LateUpdate()
    {
        // 1. Posici�n: frente al jugador (con altura fija)
        Vector3 direccionHorizontal = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
        Vector3 nuevaPosicion = cameraTransform.position + (direccionHorizontal * distanciaFrontal);
        nuevaPosicion.y = cameraTransform.position.y + alturaFija;
        transform.position = nuevaPosicion;

        // 2. Rotaci�n: 
        // - Mantiene X y Z iniciales (del Inspector)
        // - Solo actualiza el eje Y para mirar hacia la c�mara
        Vector3 rotacionActual = transform.eulerAngles;
        Vector3 rotacionCamaraY = cameraTransform.eulerAngles;
        transform.eulerAngles = new Vector3(
            initialRotation.x,      // Mant�n tu rotaci�n X inicial
            rotacionCamaraY.y,     // Sincroniza solo el eje Y con la c�mara
            initialRotation.z      // Mant�n tu rotaci�n Z inicial
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