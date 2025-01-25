using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gridMovement : MonoBehaviour
{



    [SerializeField] public float speed;

    [SerializeField] private Vector3 movePoint;

    [SerializeField] private Vector3 targetPosition;


    [SerializeField] private Vector3 input;

    [SerializeField] private bool canMove, canUseMovement;


    [SerializeField] private Vector3 cubeRadius;


    [SerializeField] private Transform playerTransform;

    [SerializeField] private Rigidbody rbPlayer;

    [SerializeField] private int sceneIndex;

    private Vector3 previousInput; // Para almacenar la entrada previa del jugador


    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        movePoint = transform.position;
    }

    // Update is called once per frame
    async Task Update()
    {
        input.z = (int)Input.GetAxisRaw("DPadVertical");
        input.x = (int)Input.GetAxisRaw("DPadHorizontal");


        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);

            // Notifica a los enemigos que el jugador se movió
            GameEvents.NotifyPlayerMove();

            if (Vector3.Distance(transform.position, movePoint) == 0)
            {
                canMove = false;

                canUseMovement = false;
            }
        }



        if ((input.x != 0 ^ input.z != 0) && !canMove && canUseMovement)
        {
            rotatePlayer();
            canMove = true;

            movePoint += input;

            previousInput = input;
        }


        if (input == Vector3.zero)
        {
            canUseMovement = true;
            previousInput = Vector3.zero;
        }
    }


    public async UniTask allowFall()
    {
        rbPlayer.constraints = RigidbodyConstraints.FreezePositionX
                               | RigidbodyConstraints.FreezePositionZ
                               | RigidbodyConstraints.FreezeRotationX
                               | RigidbodyConstraints.FreezeRotationY
                               | RigidbodyConstraints.FreezeRotationZ;

        rbPlayer.useGravity = true;

        await UniTask.Delay(1000);

        SceneManager.LoadScene(sceneIndex);


    }


    private void rotatePlayer()
    {
        if (speed != 0)
        {
            if (input.x == 1)
            {
                playerTransform.transform.rotation = Quaternion.Euler(0, 90, 0);
                return;
            }
            else if (input.x == -1)
            {
                playerTransform.transform.rotation = Quaternion.Euler(0, 270, 0);
                return;

            }

            else if (input.z == -1)
            {
                playerTransform.transform.rotation = Quaternion.Euler(0, 180, 0);
                return;

            }
            else if (input.z == 1)
            {
                playerTransform.transform.rotation = Quaternion.Euler(0, 360, 0);
                return;

            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(movePoint + targetPosition, cubeRadius);
    }


}
