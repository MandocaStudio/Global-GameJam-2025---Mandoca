using UnityEngine;

public class risita : MonoBehaviour
{
    [SerializeField] private float countdownTime = 5f; // Tiempo en segundos
    [SerializeField] private float elapsedTime = 0f; // Tiempo transcurrido

    [SerializeField] private gridMovement player;

    [SerializeField] private AudioSource soundEffect;

    [SerializeField] private AudioClip risitaClip;


    private void Start()
    {

    }



    private void Update()
    {
        // Detectar si se presiona cualquier tecla y reiniciar el contador
        if (Input.anyKeyDown || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 ||
            Input.GetAxisRaw("DPadHorizontal") != 0 || Input.GetAxisRaw("DPadVertical") != 0)
        {
            ResetTimer();
            return;
        }

        if (player.canMove && player.muelto)
        {
            elapsedTime = 0;
        }
        else if (!player.canMove || !player.muelto)
        {
            elapsedTime += Time.deltaTime;

        }


        // Si llega al tiempo límite, enviar el mensaje y reiniciar
        if (elapsedTime >= countdownTime)
        {
            soundEffect.PlayOneShot(risitaClip);
            ResetTimer(); // Reinicia el contador
        }
    }

    private void ResetTimer()
    {
        elapsedTime = 0f;
    }
}
