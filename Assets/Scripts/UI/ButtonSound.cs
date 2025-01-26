using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MenuButtonSoundManager : MonoBehaviour
{
    public AudioClip hoverSound;   // Sonido que se reproduce al pasar el puntero (hover).
    public AudioClip clickSound;   // Sonido que se reproduce al hacer clic en el botón.
    public AudioClip selectSound;  // Sonido que se reproduce cuando se selecciona con teclado/control.
    public AudioMixerGroup soundEffectsGroup;  // Grupo del Audio Mixer para estos sonidos.

    public List<Button> buttonsToConfigure;    // Lista de botones que tendrán los sonidos asignados.

    private AudioSource audioSource;

    void Start()
    {
        // Crear o buscar un AudioSource en el Canvas.
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asignar el grupo del Audio Mixer específico a este AudioSource.
        if (soundEffectsGroup != null)
        {
            audioSource.outputAudioMixerGroup = soundEffectsGroup;
        }

        audioSource.playOnAwake = false;  // Asegurarse de que no se reproduzca automáticamente.

        // Configurar los eventos de sonido para cada botón en la lista.
        foreach (Button button in buttonsToConfigure)
        {
            AddSoundEvents(button);
        }
    }

    // Método para añadir eventos de sonido a cada botón.
    private void AddSoundEvents(Button button)
    {
        // Asignar sonido de clic al evento `onClick`.
        button.onClick.AddListener(() => PlayClickSound());

        // Verificar si el botón tiene un EventTrigger y agregar uno si no lo tiene.
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = button.gameObject.AddComponent<EventTrigger>();
        }

        // Añadir el evento de `PointerEnter` para el sonido de hover.
        EventTrigger.Entry hoverEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        hoverEntry.callback.AddListener((eventData) => { PlayHoverSound(); });
        trigger.triggers.Add(hoverEntry);

        // Añadir el evento de `Select` para el sonido de selección.
        EventTrigger.Entry selectEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.Select
        };
        selectEntry.callback.AddListener((eventData) => { PlaySelectSound(); });
        trigger.triggers.Add(selectEntry);
    }

    // Método para reproducir el sonido de clic.
    public void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            EnsureAudioSourceIsActive();
            audioSource.PlayOneShot(clickSound);
        }
    }

    // Método para reproducir el sonido de hover.
    public void PlayHoverSound()
    {
        if (audioSource != null && hoverSound != null)
        {
            EnsureAudioSourceIsActive();
            audioSource.PlayOneShot(hoverSound);
        }
    }

    // Método para reproducir el sonido de selección.
    public void PlaySelectSound()
    {
        if (audioSource != null && selectSound != null)
        {
            EnsureAudioSourceIsActive();
            audioSource.PlayOneShot(selectSound);
        }
    }

    // Método para asegurar que el AudioSource esté activo antes de reproducir el sonido.
    private void EnsureAudioSourceIsActive()
    {
        // Si el AudioSource está deshabilitado, habilítalo.
        if (!audioSource.enabled)
        {
            audioSource.enabled = true;
        }

        // Si el GameObject que contiene el AudioSource está desactivado, actívalo.
        if (!audioSource.gameObject.activeSelf)
        {
            audioSource.gameObject.SetActive(true);
        }
    }
}
