using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSystem : MonoBehaviour
{
    public GameObject player; //There's 2 types, GameObject (which is a class) vs gameObjects (which is a variable that refers to a specific GameObject that the script is attached to)
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //GameObject seems to target Monobehavior class, while gameObject targets components of the object
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax); //Mathf.Clamp(float value, float min, float max); returns a float result between min and max values; Clamps the given value between the given min float and max values
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z); //youtuber literally says "you don't want to change the z because we are making a 2D game"
    }
}
