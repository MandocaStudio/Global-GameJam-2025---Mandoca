using UnityEngine;

public class enemyMovement : MonoBehaviour
{


    [SerializeField] private Transform playerTransform;

    [SerializeField] private Rigidbody rbEnemy;

    [SerializeField] private gridMovement playerScript;

    [SerializeField] private float speed;

    [SerializeField] private Vector3 targetPosition;

    [SerializeField] private Vida bubbleHealth;



    public AudioClip sonidoMuerte;



    public bool muelto;

    void Start()
    {

        playerTransform = GameObject.Find("sapito").GetComponent<Transform>();

        playerScript = GameObject.Find("sapito").GetComponent<gridMovement>();

        rbEnemy = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        if (!muelto)
        {
            GameEvents.OnPlayerMove += MoveTowardsPlayer;

        }

    }

    private void OnDisable()
    {
        GameEvents.OnPlayerMove -= MoveTowardsPlayer;

    }


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

        // int randomDirection = Random.Range(1, 3); // 1 o 2
        // if (randomDirection == 1)
        // {
        //     // Invertir la dirección para alejarse del jugador
        //     Vector3 directionAway = (transform.position - targetPosition).normalized;
        //     targetPosition = transform.position + directionAway; // Alejarse en la misma dirección
        // }

        // Mueve el objeto hacia la posición objetivo solo en un eje
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bubble"))
        {

            bubbleHealth = other.GetComponent<Vida>();
            bubbleHealth.bubbleDamage();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bubble"))
        {

            bubbleHealth = other.GetComponent<Vida>();

            if (bubbleHealth.cantidad_vida == 1)
            {
                muelto = true;
                bubbleHealth.destroyBubbleForEnemy(rbEnemy, sonidoMuerte);

            }

        }

        if (other.CompareTag("Player"))
        {
            //animacion y sonido de muerte


            playerScript.animations.Play("Armature_Fall");


            Destroy(gameObject);
        }
    }



}
