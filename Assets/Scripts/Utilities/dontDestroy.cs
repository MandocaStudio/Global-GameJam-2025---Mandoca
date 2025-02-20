using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentAudio : MonoBehaviour
{
    public static PersistentAudio instance;

    [SerializeField] private int destroyAtSceneIndex; // Índice de la escena donde se debe destruir el objeto


    private void Awake()
    {
        // Si ya existe una instancia y no es esta
        if (instance != null && instance != this && (Input.GetButtonDown("restart") || SceneManager.GetActiveScene().buildIndex != destroyAtSceneIndex))
        {
            Destroy(gameObject); // Destruir el objeto si es otro
            return;
        }


        // Marca esta instancia como la única
        instance = this;

        // Mantener este objeto persistente entre escenas
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {

        // Si estamos en la escena donde el objeto debe destruirse y el flag está activado, destrúyelo
        if (SceneManager.GetActiveScene().buildIndex == destroyAtSceneIndex || SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
            instance = null; // Limpia la referencia para permitir que un nuevo objeto tome el control
        }
    }

    public void DestroyAudioObject()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 == destroyAtSceneIndex)
        {
            Destroy(gameObject);

            instance = null;
        }
        // Limpia la referencia de la instancia
    }
}

