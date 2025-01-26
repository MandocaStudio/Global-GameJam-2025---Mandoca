using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gridMovement : MonoBehaviour
{

    public bool muelto;

    [SerializeField] public float speed;

    [SerializeField] private Vector3 movePoint;

    [SerializeField] private Vector3 targetPosition;


    [SerializeField] private Vector3 input;

    [SerializeField] private bool canMove, canUseMovement;


    [SerializeField] private Vector3 cubeRadius;


    [SerializeField] private Transform playerTransform;

    [SerializeField] private Rigidbody rbPlayer;

    [SerializeField] private int sceneIndex;

    public Animation animations;



    private Vector3 previousInput; // Para almacenar la entrada previa del jugador


    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        movePoint = transform.position;

        animations["Armature|Idle"].wrapMode = WrapMode.Loop;


        animations.Play("Armature|Idle");
    }

    // Update is called once per frame
    void Update()
    {




        input.z = (int)Input.GetAxisRaw("DPadVertical");
        input.x = (int)Input.GetAxisRaw("DPadHorizontal");


        if (canMove && !muelto && !Input.GetButton("proyectil"))
        {

            transform.position = Vector3.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);

            // Notifica a los enemigos que el jugador se movió

            if (Vector3.Distance(transform.position, movePoint) == 0)
            {
                canMove = false;

                canUseMovement = false;
            }


            moving();


        }





        if (!animations.IsPlaying("Armature|StepDown") && !muelto) // Reemplaza "OtherAnimation" con el nombre de la animación anterior
        {
            if (input.x == 0 && input.z == 0)
            {
                animations.Play("Armature|Idle");
            }
        }

        if ((input.x != 0 ^ input.z != 0) && !canMove && canUseMovement)
        {
            rotatePlayer();
            canMove = true;

            movePoint += input;

            previousInput = input;
        }


        if (Input.GetButton("proyectil"))
        {
            movePoint = transform.position;
            rotatePlayer();

        }


        if (input == Vector3.zero)
        {
            canUseMovement = true;
            previousInput = Vector3.zero;
        }
    }

    private async void moving()
    {
        await UniTask.Delay(700);
        GameEvents.NotifyPlayerMove();
    }

    public void allowFall()
    {
        rbPlayer.constraints = RigidbodyConstraints.FreezePositionX
                               | RigidbodyConstraints.FreezePositionZ
                               | RigidbodyConstraints.FreezeRotationX
                               | RigidbodyConstraints.FreezeRotationY
                               | RigidbodyConstraints.FreezeRotationZ;

        rbPlayer.useGravity = true;

        animations.Play("Armature|Fall");

    }


    private void rotatePlayer()
    {


        if (speed != 0)
        {

            if (input.x == 1)
            {
                playerTransform.transform.rotation = Quaternion.Euler(0, 90, 0);

                animations.Play("Armature|StepDown");
                return;
            }
            else if (input.x == -1)
            {
                playerTransform.transform.rotation = Quaternion.Euler(0, 270, 0);
                animations.Play("Armature|StepDown");
                return;

            }

            else if (input.z == -1)
            {
                playerTransform.transform.rotation = Quaternion.Euler(0, 180, 0);
                animations.Play("Armature|StepDown");
                return;

            }
            else if (input.z == 1)
            {
                playerTransform.transform.rotation = Quaternion.Euler(0, 360, 0);
                animations.Play("Armature|StepDown");
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
