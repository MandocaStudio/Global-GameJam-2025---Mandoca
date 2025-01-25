using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LogoController : MonoBehaviour
{
    [Header("References")]
    public RawImage rawImage;     // Aqui va la imagen de logo !!!

    [Header("Settings")]
    public float fadeDuration = 0.7f;  // La duracion del Fade In y Out, el numero asignado aplica pa entrada y salida 
    public int nextSceneIndex = 1;     // La escena que le seguira a la de logos 

    private void Start()
    {
        // Inicio del Fade
        StartCoroutine(PlayLogoSequence());
    }

    private IEnumerator PlayLogoSequence()
    {
        // Que el logo aparezca transparante para luego activar el alfa

        Color startColor = rawImage.color;
        startColor.a = 0f;
        rawImage.color = startColor;
        
        // Fade In
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Clamp01(time / fadeDuration);
            rawImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // una pausa con el logo visible en su totalidad
        yield return new WaitForSeconds(0.5f);  // Adjust as needed

        // Fade Out
        time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(time / fadeDuration);
            rawImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Cargar siguiente escena
        SceneManager.LoadScene(nextSceneIndex);
    }
}
