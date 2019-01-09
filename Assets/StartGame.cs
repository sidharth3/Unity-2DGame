using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO.Ports;
public class StartGame : MonoBehaviour {

    public Text TimeRemainingForGreenText;
    public static SerialPort sp = new SerialPort("COM7", 9600, Parity.None, 8, StopBits.One);
    // Use this for initialization
    void Start() {
        sp.Dispose();
        if (!sp.IsOpen)
        {
            sp.Open();
        }
        sp.ReadTimeout = 1; 
        StartCoroutine(Second());
    }
    IEnumerator Second()
    {
        while (1 == 1)
        {

            yield return new WaitForSeconds(1.0f);
            GreenScreen.timeToGreen--;
            TimeRemainingForGreenText.text = "Time Remaining to Play : " + (GreenScreen.timeToGreen - 20);
            if (GreenScreen.timeToGreen <= 20)
            {
               
                SceneManager.LoadScene("LeaderBoard");
                break;
            }
        }

    }
    // Update is called once per frame
    void Update () {
        if (sp.IsOpen)
        {
            try
            {
                if (sp.ReadByte()== 1)
                {
                    
                    SceneManager.LoadScene("Game");
                   
                }
            }
            catch (System.Exception)
            {


            }


        }
    }
}
