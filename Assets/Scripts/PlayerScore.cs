using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    public float timeLeft = 120;
    public int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //Debug.Log(timeLeft); //to check the time running down

        if(timeLeft < 1)
        {
            SceneManager.LoadScene("Prototype_1");
        }
    }
}
