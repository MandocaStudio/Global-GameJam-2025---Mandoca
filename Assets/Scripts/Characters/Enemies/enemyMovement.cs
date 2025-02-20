using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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



    [SerializeField] Vector3 center;


    private bool isMovingTowardsTarget = false; // Variable para controlar el estado del movimiento


    // [SerializeField] Vector3 playerPosition;



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
        // if (!animations.IsPlaying("Armature.001|MoveDownLeftRight"))
        // {
        //     animations.Play("Armature.001|Idle");

        // }


    }



    private void MoveTowardsPlayer()
    {
        if (isMovingTowardsTarget) return; // Si ya está en movimiento, no recalcular

        // Establece que el enemigo está en movimiento
        isMovingTowardsTarget = true;

        // Obtén la posición actual del enemigo
        Vector3 currentPosition = transform.position;

        // Calcula las diferencias en los ejes X y Z respecto al jugador
        float distanceX = Mathf.Abs(playerTransform.position.x - currentPosition.x);
        float distanceZ = Mathf.Abs(playerTransform.position.z - currentPosition.z);

        // Decide en qué eje moverse (prioriza el eje con mayor distancia)
        if (distanceX > distanceZ)
        {
            // Desplaza un paso en el eje X (hacia el jugador)
            targetPosition = new Vector3(currentPosition.x + Mathf.Sign(playerTransform.position.x - currentPosition.x), currentPosition.y, currentPosition.z);
        }
        else
        {
            // Desplaza un paso en el eje Z (hacia el jugador)
            targetPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + Mathf.Sign(playerTransform.position.z - currentPosition.z));
        }

        // Llama a la corrutina para mover al enemigo
        StartCoroutine(MoveToTarget(targetPosition));

        //animations.Play("Armature.001|MoveDownLeftRight");

    }


    private IEnumerator MoveToTarget(Vector3 target)
    {


        // Mueve el objeto hacia la posición objetivo
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            // Calcula la dirección del movimiento
            Vector3 direction = (target - transform.position).normalized;

            // // Solo rota si hay movimiento
            // if (direction != Vector3.zero)
            // {
            //     float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            //     transform.rotation = Quaternion.Euler(0, angle, 0); // Rotación solo en el eje Y
            // }

            // Mueve hacia el objetivo
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Reproduce la animación

            yield return null; // Espera al siguiente frame
        }

        // Asegúrate de detener en la posición exacta del objetivo
        transform.position = target;

        // Cambia el estado a "no en movimiento"
        isMovingTowardsTarget = false;

        // Reproduce la animación de idle al completar el movimiento

        //animations.Play("Armature.001|Idle");


        GameEvents.NotifyEnemyMove();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bubble"))
        {

            bubbleHealth = other.GetComponent<Vida>();
            bubbleHealth.bubbleDamage(false);

        }
    }

    // private async void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("bubble"))
    //     {


    //         Vector3 center = other.GetComponent<Collider>().bounds.center;

    //         transform.position = Vector3.MoveTowards(transform.position, center, speed * Time.deltaTime);

    //         bubbleHealth = other.GetComponent<Vida>();

    //         if (bubbleHealth.cantidad_vida == 1)
    //         {
    //             muelto = true;
    //             bubbleHealth.destroyBubbleForEnemy(rbEnemy, sonidoMuerte, animations);
    //             await UniTask.Delay(2000);



    //             GameEvents.NotifyEnemyDeath();


    //             Destroy(gameObject);
    //         }
    //         else if (bubbleHealth.cantidad_vida == 0)
    //         {
    //             muelto = true;
    //             bubbleHealth.destroyBubbleForEnemy(rbEnemy, sonidoMuerte, animations);

    //             await UniTask.Delay(2000);

    //             GameEvents.NotifyEnemyDeath();

    //             Destroy(gameObject);


    //         }



    //     }

    //     if (other.CompareTag("Player"))
    //     {
    //         //animacion y sonido de muerte
    //         playerScript.muelto = true;
    //         playerScript.allowFall();

    //         sonido.PlayOneShot(daño);
    //         Destroy(gameObject);

    //         await UniTask.Delay(1000);

    //         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //         SceneManager.LoadScene(currentSceneIndex);

    //     }

    // }



}
