using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Text getHighscore;
    // Start is called before the first frame update
    void Start()
    {
        getHighscore.text = "Highscore : "+((int)PlayerPrefs.GetFloat("Highestscore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenu()
    {
    	SceneManager.LoadScene("Game");
    }
}
