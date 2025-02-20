using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class gridMovement : MonoBehaviour
{

    public bool muelto;

    [SerializeField] public float speed;

    [SerializeField] private Vector3 movePoint;

    [SerializeField] private Vector3 targetPosition;


    [SerializeField] private Vector3 input;

    public bool canMove, canUseMovement;


    [SerializeField] private Vector3 cubeRadius;



    [SerializeField] private Rigidbody rbPlayer;
    [SerializeField] private int sceneIndex;

    //public Animation animations;
    [SerializeField] private bool enemyMoving;
    private Vector3 previousInput; // Para almacenar la entrada previa del jugador

    [SerializeField] float enemiesDeath, maxEnemiesPerLvl;
    [SerializeField] Animator playerAnimator;

    [Header("Sounds")]
    public AudioSource soundEffect;

    public AudioClip fallingAudio, laughtingAudio;

    [Header("Tile Detectors")]

    [SerializeField] private TilePosition upTile;
    [SerializeField] private TilePosition downTile;
    [SerializeField] private TilePosition leftTile;
    [SerializeField] private TilePosition rightTile;
    [SerializeField] private TilePosition currentTile;

    [SerializeField] Vector3 tileMovePoint;

    [SerializeField] PlayerInput playerInput;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();

        playerAnimator = GetComponentInChildren<Animator>();

        tileMovePoint = transform.position;

        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyMove += PlayerCanMove;
        GameEvents.OnEnemyDeath += enemiesDeathFunction;

    }

    private void PlayerCanMove()
    {
        enemyMoving = false;
        canUseMovement = true;
    }

    private void enemiesDeathFunction()
    {
        if (enemiesDeath != maxEnemiesPerLvl)
        {
            enemiesDeath += 1;

        }

    }

    void Update()
    {
        //leer entradas
        input.x = playerInput.actions["movement"].ReadValue<Vector2>().x;
        input.z = playerInput.actions["movement"].ReadValue<Vector2>().y;

        //mover y resetear inputs
        if (canUseMovement && !muelto && !Input.GetButton("proyectil") && (input.x != 0 ^ input.z != 0) && !enemyMoving)
        {
            moving();

            input.z = 0;
            input.x = 0;
        }

        if (Vector3.Distance(transform.position, tileMovePoint) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, tileMovePoint, speed * Time.deltaTime);

            canUseMovement = false;

            input.z = 0;
            input.x = 0;
        }

        if (Vector3.Distance(transform.position, tileMovePoint) < 0.1f && !canUseMovement)
        {
            enemyCanMove();
        }

    }

    private void moving()
    {

        if (input.z == 1 && upTile != null)
        {
            tileMovePoint = new Vector3(transform.position.x, transform.position.y, upTile.transform.position.z);
        }
        else if (input.z == -1 && downTile != null)
        {
            tileMovePoint = new Vector3(transform.position.x, transform.position.y, downTile.transform.position.z);
        }
        else if (input.x == 1 && rightTile != null)
        {
            tileMovePoint = new Vector3(rightTile.transform.position.x, transform.position.y, transform.position.z);

        }
        else if (input.x == -1 && leftTile != null)
        {
            tileMovePoint = new Vector3(leftTile.transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            input.z = 0;
            input.x = 0;
            return; // No se mueve si no hay un tile válido
        }

        playerAnimator.SetFloat("X", input.x);
        playerAnimator.SetFloat("Z", input.z);

    }

    private async void enemyCanMove()
    {

        if (enemiesDeath != maxEnemiesPerLvl && !enemyMoving)
        {
            enemyMoving = true;
            playerAnimator.SetTrigger("idle");

            GameEvents.NotifyPlayerMove();



        }
        else if (enemiesDeath >= maxEnemiesPerLvl)
        {
            await UniTask.Delay(700);
        }
    }

    public void allowFall()
    {

        //animations.Play("Armature|Fall");

    }


    public void setTileUp(TilePosition tile)
    {
        upTile = tile;
    }

    public void setTileDown(TilePosition tile)
    {
        downTile = tile;

    }

    public void setTileLeft(TilePosition tile)
    {
        leftTile = tile;

    }

    public void setTileRight(TilePosition tile)
    {
        rightTile = tile;

    }

    public void setTileCurrent(TilePosition tile)
    {
        currentTile = tile;

    }
}



