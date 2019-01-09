using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;


public class LeaderBoard : MonoBehaviour {
    public int Timetochange = 5;
    public Text[] HighScores;
    public Text timer;

    void sortPlayers(PlayerScore[] inputPlayers)
    {
        int n = inputPlayers.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (inputPlayers[j].getScore() < inputPlayers[j + 1].getScore())
                { 
                    PlayerScore temp = inputPlayers[j];
                    inputPlayers[j] = inputPlayers[j + 1];
                    inputPlayers[j + 1] = temp;
                }
    }

    void displayLeaderboard(PlayerScore[] inputPlayers)
    {
        for(int i = 1; i < inputPlayers.Length+1; i++)
        {
            HighScores[i].text = inputPlayers[i - 1].getName() + " " + inputPlayers[i - 1].getScore();
        }
    }

    public void CheckForHighScore(int inputScore)
    {

    }
       
    // Use this for initialization

    void Start()
    {
        StartGame.sp.Dispose();
        StartCoroutine(Fourth());
        sortPlayers(ScoreTracker.playerArray);
        displayLeaderboard(ScoreTracker.playerArray);
    }

    IEnumerator Fourth()
    {
        while (1 == 1)
        {
            Debug.Log(GreenScreen.timeToGreen);
            yield return new WaitForSeconds(1.0f);
            Timetochange--;
            GreenScreen.timeToGreen--;
            timer.text = " ";
            if (Timetochange <= 0 || GreenScreen.timeToGreen <= 0)
            {
                if(GreenScreen.timeToGreen > 20)
                {
                    SceneManager.LoadScene("Start");
                    break;
                }
                else if(GreenScreen.timeToGreen <= 0)
                {
                    SceneManager.LoadScene("Green");
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
