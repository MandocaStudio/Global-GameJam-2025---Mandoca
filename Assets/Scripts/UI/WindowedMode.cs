using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    public static ResolutionManager Instance;

    public Toggle fullscreenToggle;  // El toggle que cambiará la resolución
    public CanvasScaler[] allCanvasScalers;  // Array para todos los Canvas Scalers que debes ajustar

    // El valor de la resolución en ventana (1280x720)
    private Vector2 windowedResolution = new Vector2(1280, 720);
    private Vector2 fullscreenResolution = new Vector2(1920, 1080);

    void Awake()
    {
        // Implementación de Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Mantener el objeto entre escenas
        }
        else
        {
            
        }
    }

    void Start()
    {
        // Inicializar el estado del Toggle en función de la resolución actual
        fullscreenToggle.isOn = Screen.width == 1280 && Screen.height == 720;  // Si la resolución es 1280x720, el toggle está marcado

        // Agregar un listener para el cambio de estado del toggle
        fullscreenToggle.onValueChanged.AddListener(delegate { ToggleResolution(fullscreenToggle.isOn); });

        // Aplicar la resolución guardada (a través de todas las escenas)
        ApplyResolution(Screen.fullScreen);
    }

    // Método para alternar entre modo ventana (1280x720) y pantalla completa (1920x1080)
    void ToggleResolution(bool isWindowed)
    {
        if (isWindowed)
        {
            // Cambiar a ventana con resolución 1280x720
            Screen.SetResolution((int)windowedResolution.x, (int)windowedResolution.y, false);
            ApplyResolution(false);  // Establecer el estado a "ventana"
        }
        else
        {
            // Cambiar a pantalla completa con resolución 1920x1080
            Screen.SetResolution((int)fullscreenResolution.x, (int)fullscreenResolution.y, true);
            ApplyResolution(true);  // Establecer el estado a "pantalla completa"
        }
    }

    // Método para ajustar la resolución global y los Canvas Scalers
    void ApplyResolution(bool isFullscreen)
    {
        // Ajustar todos los Canvas Scalers a la resolución correspondiente
        foreach (var canvasScaler in allCanvasScalers)
        {
            // Esto ajusta la resolución de referencia de todos los Canvas Scalers
            canvasScaler.referenceResolution = windowedResolution;
        }
    }
}
