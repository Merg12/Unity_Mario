using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public float timeLeft = 20;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //Debug.Log(timeLeft); //to check the time running down
        timeLeftUI.gameObject.GetComponenet<Text>().text = ("Time Left: " + timeLeft);

        if(timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Prototype_1");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        //Debug.Log("Touched the endLevel wall!");
        CountScore();
    }

    void CountScore()
    {
        playerScore = playerScore + ((int)timeLeft * 10);
        Debug.Log(playerScore);
    }
}
