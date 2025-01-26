using UnityEngine;

public class ReturnToMainMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;   // Panel del Menú Principal
    [SerializeField] private GameObject optionsPanel;     // Panel de Opciones

    public void ReturnToMainMenu()
    {
        // Activa el Panel del Menú Principal y desactiva el Panel de Opciones
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
}
