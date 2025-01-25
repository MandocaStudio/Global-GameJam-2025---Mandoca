using UnityEngine;

public class Vida : MonoBehaviour
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


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Enemigo" || other.gameObject.tag == "Player")
        {
            cantidad_vida -= 1;
            //cambia el color de la esfera                 
        }

    }
}
