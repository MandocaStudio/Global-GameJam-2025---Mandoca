using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMovement : MonoBehaviour
{


    [SerializeField] private Transform playerTransform;

    [SerializeField] private Rigidbody rbEnemy;

    [SerializeField] private gridMovement playerScript;

    [SerializeField] private float speed;

    [SerializeField] private Vector3 targetPosition;

    [SerializeField] private Vida bubbleHealth;



    public AudioClip sonidoMuerte, daño;

    public AudioSource sonido;

    public bool muelto;

    [SerializeField] private Animation animations;

    void Start()
    {

        playerTransform = GameObject.Find("sapito").GetComponent<Transform>();

        playerScript = GameObject.Find("sapito").GetComponent<gridMovement>();

        rbEnemy = GetComponent<Rigidbody>();

        animations["Armature.001|Idle"].wrapMode = WrapMode.Loop;

        animations.Play("Armature.001|Idle");
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


    private void Update()
    {
        if (!animations.IsPlaying("Armature.001|MoveUp"))
        {
            animations.Play("Armature.001|Idle");

        }
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

        // Calcula la dirección del movimiento
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Solo rota si hay movimiento
        if (direction != Vector3.zero)
        {
            // Calcula la rotación hacia el eje del movimiento
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0); // Rotación solo en el eje Y
        }

        // Mueve el objeto hacia la posición objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Reproduce la animación
        animations.Play("Armature.001|MoveDownLeftRight");
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bubble"))
        {

            bubbleHealth = other.GetComponent<Vida>();
            bubbleHealth.bubbleDamage();

        }
    }

    private async void OnTriggerEnter(Collider other)
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
            playerScript.muelto = true;
            playerScript.allowFall();

            sonido.PlayOneShot(daño);
            Destroy(gameObject);

            await UniTask.Delay(1000);

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }



}
