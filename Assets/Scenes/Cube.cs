using System.IO.Ports;
using UnityEngine;


public class Cube : MonoBehaviour
{
    private float distanceToMove;
    public float speed;
    SerialPort sp = new SerialPort("COM7", 9600);


    // Use this for initialization
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = speed * Time.deltaTime;
        if (sp.IsOpen)
        {
            try
            {
                if (sp.ReadByte() == 1)
                {

                    transform.Translate(0, 0.1f, 0);

                }

                else if (sp.ReadByte() == 2)
                { 

                    transform.Translate(Vector3.right * distanceToMove * 5);

                }
            }
            catch (System.Exception)
            {


            }


        }

    }
}

    
    




