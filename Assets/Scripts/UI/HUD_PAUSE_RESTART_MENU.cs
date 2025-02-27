using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [Header("Escena del Menú Principal")]
    [SerializeField] private int mainMenuSceneIndex = 0;

    [Header("Panel de Pausa")]
    [SerializeField] private GameObject pauseCanvas;

    private bool isPaused = false;

    [SerializeField] AudioClip plop;

    [SerializeField] AudioSource sonidos;


    [SerializeField] private bool isUsingController;

    void Update()
    {

        // if (playerInput.currentControlScheme == "Gamepad")
        // {
        //     Debug.Log("se ha usado gamepad");
        // }
        // else if (playerInput.currentControlScheme == "teclado")
        // {
        //     Debug.Log("se ha usado teclado");

        // }

        // Detectar botón de Pausa (Start en Xbox y PlayStation)
        if (Input.GetButtonDown("menu"))
        {
            PauseOrResumeGame();
        }

        // Detectar botón de Reinicio (Y / Triángulo)
        if (Input.GetButtonDown("restart"))
        {
            RestartCurrentScene();
        }

        // Detectar botón de Salir (B / Círculo)
        if (Input.GetButtonDown("exit"))
        {
            LoadMainMenu();
        }
    }

    // Método que puede llamarse desde el botón de Pausa (en UI) o por código
    public void PauseOrResumeGame()
    {

        sonidos.PlayOneShot(plop);
        if (!isPaused)
        {
            // Pausar
            Time.timeScale = 0f;
            isPaused = true;
            if (pauseCanvas != null) pauseCanvas.SetActive(true);
        }
        else
        {
            // Reanudar
            Time.timeScale = 1f;
            isPaused = false;
            if (pauseCanvas != null) pauseCanvas.SetActive(false);
        }
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;  // Asegurar que se reanude
        isPaused = false;
        if (pauseCanvas != null) pauseCanvas.SetActive(false);
    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene(mainMenuSceneIndex);
        Time.timeScale = 1f; // Asegurar que se reanude
        isPaused = false;
        if (pauseCanvas != null) pauseCanvas.SetActive(false);
    }
}
