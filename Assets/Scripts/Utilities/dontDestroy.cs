using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance;
    private int previousSceneIndex = -1; // Variable para almacenar el índice de la escena anterior

    private void Awake()
    {
        // Si ya existe una instancia, destruye este objeto
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Marca esta instancia como única y no destruir al cargar nueva escena
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Suscribirse al evento de carga de escenas
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Obtén el índice de la escena cargada
        int sceneIndex = scene.buildIndex;

        // Puedes registrar o usar el índice como necesites
        Debug.Log("La escena cargada tiene el índice: " + sceneIndex);

        // Verifica si pasamos de la escena 3 a la escena 4
        if (previousSceneIndex == 3 && sceneIndex == 4)
        {
            Debug.Log("Se ha pasado de la escena 3 a la 4, destruyendo el objeto.");
            Destroy(gameObject);
        }

        // Guarda el índice de la escena actual como la escena anterior
        previousSceneIndex = sceneIndex;
    }

    private void OnDestroy()
    {
        // Asegúrate de desuscribirte cuando el objeto sea destruido
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

