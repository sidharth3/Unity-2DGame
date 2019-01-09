using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PromptSCr : MonoBehaviour {
    public Text timeremtext;
    int timerem = 5;


    // Use this for initialization
    void Start() {
        StartCoroutine(Third());

    }
        IEnumerator Third()
        {
            while (1 == 1)
            {

                yield return new WaitForSeconds(1.0f);
                timerem--;
                timeremtext.text = "Time Remaining to Play : " + timerem;
                if (timerem <= 0)
                {
                    SceneManager.LoadScene("LeaderBoard");
                    break;
                }
            }

        }
    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Start");
            
        }
    }
}
