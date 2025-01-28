using UnityEngine;
using UnityEngine.SceneManagement;

public class recolectar : MonoBehaviour
{
    public int recolectado;

    [SerializeField] private int NextLevelAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        recolectado = 0;
    }


    public void comprobacion(int valorMoneda)
    {
        recolectado += valorMoneda;
        if (recolectado == NextLevelAmount)
        {

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (PersistentAudio.instance != null)
            {
                PersistentAudio.instance.DestroyAudioObject();
            }

            // Carga la siguiente escena sumando 1 al índice actual
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }



}
