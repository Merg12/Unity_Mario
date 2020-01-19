using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //we want this for security of our save data

public class DataManagement : MonoBehaviour
{
    public static DataManagement dataManagement;
    public int highScore;
    void Awake() //the code in this scope Awake() called the single tint design pattern, this object stays with scene from scene to scene, level to level
    {
        if(dataManagement == null) //so if there's no object in dataManagement...
        {
            DontDestroyOnLoad(gameObject); //...then don't destroy this gameObject... 
            dataManagement = this; //...instead, assign 'this' gameObject into dataManagement; this refers to the current instance of the class; basically the gameObject
        }
        else if(dataManagement != this) //...but if dataManagement doesn't have 'this' <current> gameObject in it...
        {
            Destroy(gameObject); //..then destroy the gameObject that's been there from previous
        }
    }

    public void SaveData() //data is saved
    {
        BinaryFormatter BinForm = new BinaryFormatter(); //creates a binary formatter
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //creates file at this location

        gameData data = new gameData(); //creates container for data
        data.highscore = highScore; //gets value from our public in highScore into our data.highscore container
        //data.coins = Coins; //extra here if you want to add in coins data, but do it yourself

        BinForm.Serialize(file, data); //serializes data into a file
        file.Close(); //closes file
        //PlayerPrefs.SetInt("HighScore", 10); //.SetInt(string key, int value)
        //PlayerPrefs.GetInt("HighScore");        
    }

    public void LoadData() //data is loaded
    {
        if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter BinForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)BinForm.Deserialize(file);
            file.Close();
            highScore = data.highscore;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

[Serializable]
class gameData
{
    public int highscore;
}
