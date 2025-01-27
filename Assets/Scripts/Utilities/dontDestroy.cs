using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance;

    private void Awake()
    {
        // Verificar si la escena actual es la de índice 0


        // Si ya existe una instancia, destruye este objeto
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Marca esta instancia como única y no destruir al cargar nueva escena
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(gameObject);
            return;
        }
    }
}
