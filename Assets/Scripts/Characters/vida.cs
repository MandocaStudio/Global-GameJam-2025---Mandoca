using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float cantidad_vida = 3;
    public Renderer objectRenderer;
    public Material color1, color2, color3;

    [SerializeField] private GameObject bubbleVFX;

    [SerializeField] private MeshRenderer bubbleMeshRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        bubbleMeshRenderer = GetComponent<MeshRenderer>();

        if (cantidad_vida == 3)
        {
            objectRenderer.material = color1;
        }
        else if (cantidad_vida == 2)
        {
            objectRenderer.material = color2;
        }
        else if (cantidad_vida == 1)
        {
            objectRenderer.material = color3;
        }

        bubbleVFX = transform.GetChild(0).gameObject;

        bubbleVFX.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bubbleDamage();

        }

    }

    public void bubbleDamage()
    {
        cantidad_vida -= 1;
        if (cantidad_vida == 2)
        {
            objectRenderer.material = color2;
        }
        if (cantidad_vida == 1)
        {
            objectRenderer.material = color3;
        }
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cantidad_vida == 1)
            {
                gridMovement playerScript = other.collider.GetComponent<gridMovement>();
                destroyBubbleForPlayer(playerScript);
            }
        }

        // else if (other.gameObject.CompareTag("Enemigo"))
        // {
        //     if (cantidad_vida == 1)
        //     {
        //         enemyMovement enemyScript = other.collider.GetComponent<enemyMovement>();
        //         destroyBubbleForEnemy(enemyScript);
        //     }
        // }
    }

    public async void destroyBubbleForEnemy(Rigidbody rbEnemy, AudioClip sonido)
    {
        await UniTask.Delay(500);
        bubbleVFX.SetActive(true);
        bubbleMeshRenderer.enabled = false;

        rbEnemy.constraints = RigidbodyConstraints.FreezePositionX
                       | RigidbodyConstraints.FreezePositionZ
                       | RigidbodyConstraints.FreezeRotationX
                       | RigidbodyConstraints.FreezeRotationY
                       | RigidbodyConstraints.FreezeRotationZ;

        rbEnemy.useGravity = true;

        AudioSource soundEffects = GameObject.Find("efectos").GetComponent<AudioSource>();

        soundEffects.PlayOneShot(sonido);

        Destroy(gameObject);


    }

    private async void destroyBubbleForPlayer(gridMovement Player)
    {
        await UniTask.Delay(500);
        Player.muelto = true;

        //Player.speed = 0;
        bubbleVFX.SetActive(true);

        bubbleMeshRenderer.enabled = false;

        await UniTask.Delay(1000);

        await Player.allowFall();
        Destroy(gameObject);



    }
}
