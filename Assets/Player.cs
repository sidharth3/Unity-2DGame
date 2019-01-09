using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject playerchar;
    

    void Start()
    {
        playerchar = GameObject.Find("playerchar");
        playerchar.SetActive(true);
        StartCoroutine(Todestroy());
    }
    // Update is called once per frame
    IEnumerator Todestroy()
    {
        yield return new WaitForSeconds(10);
        playerchar.SetActive(false);
        yield return new WaitForSeconds(5);
        playerchar.SetActive(true);


    }

    void Update()
    {
       
        
    }

}