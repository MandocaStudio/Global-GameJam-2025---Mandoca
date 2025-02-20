using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public float cantidad_vida = 3;
    public Renderer objectRenderer;
    public Material color1, color2, color3;

    [SerializeField] private GameObject bubbleVFX;

    [SerializeField] private MeshRenderer bubbleMeshRenderer;

    [SerializeField] AudioClip amarillo, rojo, rojoRojito;

    [SerializeField] AudioSource sonidos;

    [SerializeField] AudioSource sonidosBurbuja;


    [SerializeField] BoxCollider Collider;

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

    public async void bubbleDamage(bool soundEffectActiveForPlayer)
    {
        cantidad_vida -= 1;
        if (cantidad_vida == 2)
        {
            objectRenderer.material = color2;
            if (soundEffectActiveForPlayer)
            {
                sonidosBurbuja.PlayOneShot(amarillo);

            }
        }
        if (cantidad_vida == 1)
        {
            objectRenderer.material = color3;

            if (soundEffectActiveForPlayer)
            {
                sonidosBurbuja.PlayOneShot(rojo);
            }
        }

        if (cantidad_vida == 0)
        {
            bubbleMeshRenderer.enabled = false;
            bubbleVFX.SetActive(true);

            if (soundEffectActiveForPlayer)
            {
                sonidosBurbuja.PlayOneShot(rojoRojito);
            }

            await UniTask.Delay(2000);

            Destroy(gameObject);

        }
    }


}
