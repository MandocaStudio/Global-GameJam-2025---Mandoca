using UnityEngine;

public class contolArma : MonoBehaviour
{
    public Transform disparo;
    public bool disparando;
    public GameObject airBullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        disparando = Input.GetButtonDown("proyectil");
        if(disparando){
            instanciarBala();
        }

        
    }
    public void instanciarBala(){
        Instantiate(airBullet, disparo.position, disparo.rotation);
    }
}
