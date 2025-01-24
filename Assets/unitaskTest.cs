using UnityEngine;
using Cysharp.Threading.Tasks;


public class unitaskTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            unitaskTestFunction().Forget();

        }
    }

    private async UniTask unitaskTestFunction()
    {
        Debug.Log("aqui empieza");
        await UniTask.Delay(10000);
        Debug.Log("aqui termina");

    }
}
