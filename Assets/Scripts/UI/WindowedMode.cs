 using UnityEngine;
using UnityEngine.UI;

public class WindowedModeToggle : MonoBehaviour
{
    public Toggle fullscreenToggle;

    void Start()
    {
        // Inicializar el toggle para reflejar el estado actual de pantalla completa (fullscreen).
        fullscreenToggle.isOn = !Screen.fullScreen;  // Aquí invertimos el valor para que "marcado" sea windowed mode

        // Agregar el listener para que se ejecute cuando se cambie el valor del toggle
        fullscreenToggle.onValueChanged.AddListener(delegate { ToggleWindowedMode(fullscreenToggle.isOn); });
    }

    // Método para alternar entre modo ventana (windowed) y pantalla completa (fullscreen)
    public void ToggleWindowedMode(bool isWindowed)
    {
        Screen.fullScreen = !isWindowed; // Si el toggle está marcado (windowed), activamos fullscreen 
    }
}
