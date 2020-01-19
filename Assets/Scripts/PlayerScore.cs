using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public float timeLeft = 20; //must be a float because it's a part of Time.deltaTime
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;


    // Start is called before the first frame update
    void Start()
    {
        DataManagement.dataManagement.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; //public static float time.deltaTime
        //Debug.Log(timeLeft); //to check the time running down
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);

        if(timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Prototype_1");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.name == "endLevel") //points added for ending the level
        {
           //Debug.Log("Touched the endLevel wall!");
            CountScore(); 
        }
        if(trig.gameObject.name == "coin") //points added for grabbing a coin
        {
            playerScore += 10;
            Destroy(trig.gameObject); //coin disappears when grabbed
        }
    }

    void CountScore()
    {
        Debug.Log("Data says high score is currently: " + DataManagement.dataManagement.highScore);
        playerScore = playerScore + ((int)timeLeft * 10);
        DataManagement.dataManagement.highScore = playerScore + (int)(timeLeft * 10);
        Debug.Log(playerScore);
        DataManagement.dataManagement.SaveData(); //calls the save data from DataManagement.cs
        Debug.Log("Now that we have added the score to DataManagement, high score is now: " + DataManagement.dataManagement.highScore);
    }
}
