using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float cantidad_vida = 3;
    public Renderer objectRenderer;
    public Material color1, color2, color3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

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
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Enemigo") || other.gameObject.CompareTag("Player"))
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

    }

    private async UniTask OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemigo"))
        {
            if (cantidad_vida == 1)
            {
                gridMovement playerScript = other.collider.GetComponent<gridMovement>();
                await destroyBubble(playerScript);
            }
        }
    }

    private async UniTask destroyBubble(gridMovement Player)
    {
        await UniTask.Delay(500);
        Player.speed = 0;
        Destroy(gameObject);
    }
}
