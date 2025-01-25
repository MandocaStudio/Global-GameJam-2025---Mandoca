using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Canvas optionsCanvas; // Asigna el OptionsCanvas desde el Inspector

    // Método para el botón "Play"
    public void PlayGame(int sceneIndex)
    {
        // Cargar la escena con el índice especificado
        SceneManager.LoadScene(sceneIndex);
    }

    // Método para el botón "Options"
    public void ShowOptions()
    {
        // Activar el Canvas de Opciones
        optionsCanvas.gameObject.SetActive(true);
    }

    // Método para cerrar el Panel de Opciones
    public void CloseOptions()
    {
        // Desactivar el Canvas de Opciones
        optionsCanvas.gameObject.SetActive(false);
    }

    // Método para el botón "Quit"
    public void QuitGame()
    {
        // Salir del juego
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
