using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneManager : MonoBehaviour
{
    [SerializeField] private float delayBeforeExit = 10f;  // Tiempo de espera en segundos
    [SerializeField] private int sceneIndexToLoad = 0;     // Índice de la escena a cargar (por defecto, 0)

    void Start()
    {
        // Inicia la corrutina que esperará 'delayBeforeExit' y luego cambiará de escena
        StartCoroutine(WaitAndLoadScene());
    }

    private System.Collections.IEnumerator WaitAndLoadScene()
    {
        // Espera los 10 segundos (o el valor que tengas en delayBeforeExit)
        yield return new WaitForSeconds(delayBeforeExit);

        // Carga la escena de índice especificado
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
