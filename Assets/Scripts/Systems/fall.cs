using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fall : MonoBehaviour
{

    [SerializeField] AudioClip sonidoCaida;

    [SerializeField] AudioSource soundEffect;
    private async void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gridMovement player = other.collider.GetComponent<gridMovement>();

            await UniTask.Delay(300);


            player.muelto = true;

            player.allowFall();

            soundEffect.PlayOneShot(sonidoCaida);

            await UniTask.Delay(1000);

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);

        }
    }
}
