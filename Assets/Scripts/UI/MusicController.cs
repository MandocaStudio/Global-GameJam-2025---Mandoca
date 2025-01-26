using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MasterVolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private const string EXPOSED_PARAM = "VolMaster"; // Debe coincidir con tu parámetro expuesto en el Mixer

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(EXPOSED_PARAM, 0.75f);
        volumeSlider.value = savedVolume;
        SetMasterVolume(savedVolume);

        volumeSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    public void SetMasterVolume(float volume)
    {
        // Convierte el valor de 0-1 a Decibelios (ej. -80 a 0 dB aprox)
        audioMixer.SetFloat(EXPOSED_PARAM, Mathf.Log10(volume) * 20);

        // Guarda en PlayerPrefs
        PlayerPrefs.SetFloat(EXPOSED_PARAM, volume);
    }
}
