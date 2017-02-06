using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingletonConfig : MonoBehaviour {

    int level;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        level = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            level = (int)GameObject.Find("Slider").GetComponent<Slider>().value;
            SceneManager.LoadScene("demo");
        }
        
    }
}
