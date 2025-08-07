using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CambioEscenaGaze : MonoBehaviour
{
    [SerializeField] private string escenaDestino = "EscenaPrueba01";
    [SerializeField] private Animator fadeAnimator; // arrástralo desde el inspector
    [SerializeField] private float tiempoDeFade = 1f;

    public void OnPointerClickXR()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            StartCoroutine(CambiarEscenaConTransicion());
            return;
        }

        if (!InventarioManager.Instance.Inicio)
            InventarioManager.Instance.Inicio = true;

        StartCoroutine(CambiarEscenaConTransicion());
    }

    private IEnumerator CambiarEscenaConTransicion()
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(tiempoDeFade);
        SceneManager.LoadScene(escenaDestino);
    }
}
