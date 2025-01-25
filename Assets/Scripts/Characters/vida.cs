using UnityEngine;

public class vida : MonoBehaviour
{
    public float cantidad_vida = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollitionEnter(Collision collision){
            Debug.Log("Colision");
        }
        void OnCollitionStay (Collision collision){
            Debug.Log ("ENCIMA");
        }
        void OnCollitionExit (Collision collision){
            if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "jugador"){
                cantidad_vida -= 1;
                //cambia el color de la esfera                 
            }

        }
}
