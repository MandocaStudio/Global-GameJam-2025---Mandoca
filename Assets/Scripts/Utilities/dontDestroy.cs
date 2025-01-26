using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance;

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
    }
}
