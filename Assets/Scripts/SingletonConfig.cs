using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingletonConfig : MonoBehaviour {

    int m_level;
    int m_score;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        m_level = 0;
        m_score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            m_level = (int)GameObject.Find("Slider").GetComponent<Slider>().value;
            GameObject.Find("Level").GetComponent<Text>().text = "Level " + m_level;
        }
	}

    public void StartGame()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            SceneManager.LoadScene("demo");
        }
        
    }

    public void StartCreation()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            SceneManager.LoadScene("CreateTetrimino");
        }
    }

    public void ReturnToMainMenu()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public int GetLevel()
    {
        return m_level;
    }

    public void IncrementScore(int score)
    {
        m_score += score;
    }

    public int GetScore()
    {
        return m_score;
    }
}
