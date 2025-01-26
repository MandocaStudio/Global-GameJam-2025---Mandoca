using UnityEngine;

public class recolectar : MonoBehaviour
{
    public static int recolectado = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Premio"){
                recolectar.recolectado++;
            }
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
