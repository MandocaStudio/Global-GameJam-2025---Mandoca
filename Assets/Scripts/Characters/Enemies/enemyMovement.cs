using UnityEngine;

public class enemyMovement : MonoBehaviour
{


    [SerializeField] private Transform playerTransform;

    [SerializeField] private float speed;

    [SerializeField] private Vector3 targetPosition;

    [SerializeField] private Vida bubbleHealth;

    void Start()
    {

        playerTransform = GameObject.Find("sapito").GetComponent<Transform>();
    }


    private void OnEnable()
    {
        GameEvents.OnPlayerMove += MoveTowardsPlayer;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerMove -= MoveTowardsPlayer;
    }

    // Update is called once per frame
    private void MoveTowardsPlayer()
    {

        // Obtén la posición objetivo (del jugador)
        targetPosition = playerTransform.position;

        // Calcula las diferencias en los ejes X y Z
        float distanceX = Mathf.Abs(targetPosition.x - transform.position.x);
        float distanceZ = Mathf.Abs(targetPosition.z - transform.position.z);

        // Decide en qué eje moverse (prioriza el eje con mayor distancia)
        if (distanceX > distanceZ)
        {
            // Mueve en el eje X
            targetPosition.z = transform.position.z; // Mantén la posición Z actual
        }
        else
        {
            // Mueve en el eje Z
            targetPosition.x = transform.position.x; // Mantén la posición X actual
        }

        // Mueve el objeto hacia la posición objetivo solo en un eje
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bubble"))
        {
            bubbleHealth = other.GetComponent<Vida>();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bubble"))
        {


            bubbleHealth.cantidad_vida -= 1;
        }
    }



}
