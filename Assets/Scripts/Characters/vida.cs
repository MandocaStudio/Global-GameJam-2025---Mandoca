using UnityEngine;

public class Vida : MonoBehaviour
{
    public float cantidad_vida = 3;
    public Rendered objectRendered;
    public Material color;

    
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
            if (cantidad_vida == 2){
                objectRendered.material = color2; 
            }
            if (cantidad_vida == 1){
                objectRendered.material = color3;
            }
            if (cantidad_vida == 0){
                
            }                 
        }

    }
}
