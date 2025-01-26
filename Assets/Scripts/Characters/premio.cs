using UnityEngine;

public class premio : MonoBehaviour
{

    public static int contarPremio = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        premio.contarPremio = contarPremio + 1;
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            premio.contarPremio--;
        }

        if(contarPremio == 0){
            //llamar al siguiente nivel
            Debug.Log("Siguiente nivel");
        }

        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
