using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class RepeatingLadder : MonoBehaviour {
    private BoxCollider2D groundCollider;
    private float groundVerticalLength;
    public int score = 0;
    GameObject ladderobj;
    GameObject ladderobj2;

    // Use this for initialization
    void Start () {
      
        groundCollider = GetComponent<BoxCollider2D> ();
        groundVerticalLength = groundCollider.size.y;
        //anim = GetComponent<Animator>();
        //anim.SetInteger("AnimationState", 1);
        newPositionY = transform.position.y;
        ladderobj = GameObject.Find("Ladder");
        ladderobj2 = GameObject.Find("Ladder2");
        ladderobj.SetActive(true);
        ladderobj2.SetActive(true);
        StartCoroutine(DestroyLadder());
    }
    
    float newPositionY = 0;
    // Update is called once per frame

    bool first = false;
    int state = 0;
    public Sprite char1;
    public Sprite char2;

    IEnumerator DestroyLadder() {
        yield return new WaitForSeconds(10);
        ladderobj.SetActive(false);
        ladderobj2.SetActive(false);
        yield return new WaitForSeconds(5);
        ladderobj2.SetActive(true);
        ladderobj.SetActive(true);

    }


    void Update () {
        //SerialPort sp = GetScoreTrackerSP();
       
        if (!first)
        {
            newPositionY = transform.position.y;
            first = true;
        }

        if (StartGame.sp.IsOpen)
        {
            try
            {
                //Debug.Log("reading byte");

                if (ScoreTracker.previousTotalClicks != ScoreTracker.totalClicks)
                {
                   // Debug.Log("byte received");

                    newPositionY -= 4;

                    if (char1 == null)
                    {
                        return;
                    }
                    GameObject.Find("playerchar").GetComponent<SpriteRenderer>().sprite = state == 0 ? char1 : char2;
                    state = state == 0 ? 1 : 0;

                }
            }
            catch (System.Exception)
            {


            }
        }
        else
        {
            //Debug.Log("SP NOT OPEN");
        }
        Vector3 dir = new Vector3(transform.position.x, newPositionY, 0) - transform.position;
        float speed = dir.magnitude* dir.magnitude;
        if (dir.magnitude > 1)
        { 
            transform.position = transform.position + dir.normalized * speed * Time.deltaTime;
        }


        if (transform.position.y < -groundVerticalLength) {
            Reposition();
        }
	}

    private void Reposition()
    {
        Vector2 GroundOffset = new Vector2(0, groundVerticalLength * 2f);
        transform.position = (Vector2)transform.position + GroundOffset;
        newPositionY = newPositionY + GroundOffset.y;

    }

   /* SerialPort GetScoreTrackerSP()
    {
        return GameObject.Find("GameObject").GetComponent<ScoreTracker>().sp;
    }*/

}
