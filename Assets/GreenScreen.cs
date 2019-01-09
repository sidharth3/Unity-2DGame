using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GreenScreen : MonoBehaviour {
    public int greenTime;
    public static int timeToGreen = 50;
    
	// Use this for initialization
	void Start () {
        StartGame.sp.Dispose();
        StartCoroutine(Fifth());
        greenTime = 5;
        timeToGreen = 50;
	}
	IEnumerator Fifth() {
        while (1 == 1) {
            yield return new WaitForSeconds(1.0f);
            greenTime--;
            if (greenTime <= 0) {
                SceneManager.LoadScene("Start");
            }

           

        }

    }
	// Update is called once per frame
	void Update () {
		
	}
}
