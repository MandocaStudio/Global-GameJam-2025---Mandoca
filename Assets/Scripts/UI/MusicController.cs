using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MasterVolumeController : MonoBehaviour
{
    public AudioMixer audioMixer; // Arrastra tu AudioMixer aquí desde el Inspector
    public Slider volumeSlider;  // Asigna el Slider desde el Inspector

    private const string MasterVolumeKey = "Master"; // Clave para guardar en PlayerPrefs

    void Start()
    {
        // Cargar el valor guardado o usar un valor predeterminado si no existe
        float savedVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 0.75f);

        // Aplicar el valor guardado al Slider
        volumeSlider.value = savedVolume;

        // Aplicar el valor guardado al AudioMixer
        SetMasterVolume(savedVolume);

        // Agregar listener para detectar cambios en el Slider
        volumeSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    public void SetMasterVolume(float volume)
    {
        // Convertir el volumen del Slider a dB y aplicarlo al AudioMixer
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

        // Guardar el valor en PlayerPrefs
        PlayerPrefs.SetFloat(MasterVolumeKey, volume);
    }
}
