using UnityEngine;

public class bala : MonoBehaviour
{
    public int direccionBala;
    public bool disparo = false;
    public int distanciaFinal = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void direccionBala(){
            if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("joystick button 14")){
                if (input.x == 1 && disparo == true)
                {
                    playerTransform.transform.rotation = Quaternion.Euler(0, 90, 0);
                    return;
                }
                else if (input.x == -1 && disparo == true)
                {
                    playerTransform.transform.rotation = Quaternion.Euler(0, 270, 0);
                    return;

                }

                else if (input.z == -1 && disparo == true)
                {
                    playerTransform.transform.rotation = Quaternion.Euler(0, 180, 0);
                    return;

                }
                else if (input.z == 1 && disparo == true)
                {
                    playerTransform.transform.rotation = Quaternion.Euler(0, 360, 0);
                    return;

                }   
            }
        }
    }
}
