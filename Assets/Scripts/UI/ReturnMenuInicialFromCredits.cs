using UnityEngine;

public class ReturnToMainMenuButtonFromCredits : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;   // Panel del Menú Principal
    [SerializeField] private GameObject  CreditsPanel;     // Panel de Opciones

    public void ReturnToMainMenuFromCredits()
    {
        // Activa el Panel del Menú Principal y desactiva el Panel de Opciones
        mainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
}
