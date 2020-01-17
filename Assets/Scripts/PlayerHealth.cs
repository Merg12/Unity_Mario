using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(gameObject.transform.position.y < -7)
        {
            Debug.Log("Player Has Died!");
        }*/ //solely for testing to see if the code would work, look below for the actual part

        if(gameObject.transform.position.y < -7)
        {
            /*hasDied = true;*/
            Die();
        }

        /*if(hasDied == true)
        {
            StartCoroutine("Die");
        }*/
    }

    void Die()
    {
        SceneManager.LoadScene("Prototype_1"); //this is the actual name of the scene in project folder
    }

    /*IEnumerator Die()
    {
        SceneManager.LoadScene("Prototype_1");
        yield return null;

        Debug.Log("Player Has Fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player Has Died");
    }*/
}
