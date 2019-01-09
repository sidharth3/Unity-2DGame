using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class PlayerScore
{
    private string name = "temp";
    private int score = 0;

    public PlayerScore()
    {
    }

    public void setName(string inputName)
    {
        name = inputName;
    }

    public void setScore(int inputScore)
    {
        score = inputScore;
    }

    public string getName()
    {
        return name;
    }

    public int getScore()
    {
        return score;
    }
}

public class ScoreTracker : MonoBehaviour {
    public GameObject inputField;
    public GameObject tryhard;
    public Text Counter;
    public Text TimeRemainingText;
    public static int TimeRemainingEndGame = 15;
    public static int totalClicks = 0;
    public static int timetodestroy = 10;
    public static int previousTotalClicks = 0;
    public static string playername;
    bool gameinplay = true;
    public Text tryagain;
    public InputField forplayername;
    public static PlayerScore player1 = new PlayerScore();
    public static PlayerScore player2 = new PlayerScore();
    public static PlayerScore player3 = new PlayerScore();
    public static PlayerScore player4 = new PlayerScore();
    public static PlayerScore player5 = new PlayerScore();
    public static PlayerScore[] playerArray = new PlayerScore[5] { player1, player2, player3, player4, player5 };
    private string tempName;
    int fifthscore = playerArray[4].getScore();

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start () {
        StartCoroutine(OneSecond());
        inputField = GameObject.Find("InputField");
        inputField.SetActive(false);
        tryhard = GameObject.Find("tryagainprompt");
        tryhard.SetActive(false);
        totalClicks = 0;
        previousTotalClicks = 0;

        //forplayername.text = playername;
            
    }
    IEnumerator OneSecond()
    {
        while (1 == 1)
        {

            yield return new WaitForSeconds(1.0f);
            TimeRemainingEndGame--;
            //timetodestroy--;
            GreenScreen.timeToGreen--;
            TimeRemainingText.text = "Time: " + (TimeRemainingEndGame - 5);
            if (TimeRemainingEndGame <= 5)
            {
                TimeRemainingText.text = "Time: 0";
                gameinplay = false;
                if (totalClicks > fifthscore)
                {
                    TimeRemainingText.text = "Time: 0";
                    inputField.SetActive(true);
                    playerArray[4].setScore(totalClicks);
                    if (TimeRemainingEndGame <= 0)
                    {
                        //Destroy(gameObject);
                        playerArray[4].setName(forplayername.text);
                        EndGame();
                        break;
                        
                    }
                }
                else
                {
                    tryhard.SetActive(true);
                    tryagain.text = "You did not get a highscore!" + "\r\n" + "Try again next time!";
                    if (TimeRemainingEndGame <= 0)
                    {
                       // Destroy(gameObject);
                        EndGame();
                        break;
                    }
                }
            }

        }   

    }

    
    // Update is called once per frame
    void Update () {

        previousTotalClicks = totalClicks;

        if (!gameinplay)
        { return; }

        if (StartGame.sp.IsOpen)
        {
            try
            {
                if (StartGame.sp.ReadByte() == 1)
                {
                    totalClicks++;
                    Counter.text = "Score: " + totalClicks;
                }
            }
            catch (System.Exception)
            { }
            
        }
    }
    
    void EndGame()
    {
            gameinplay = false;
            SceneManager.LoadScene("Leaderboard");
           // SceneManager.sceneLoaded += CheckHighscore;
        
       
    }


}
