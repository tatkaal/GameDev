using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	private float score = 0.0f;
	public Text scoreText;
	private int difficultyLevel = 1;
	private int maxDifficultyLevel = 3;
	private int scoreToNextLevel = 10; 

	private bool isDead = false;

	public DeathMenu deathmenu;
    // Start is called before the first frame update
    void Start()
    {
    	
    }

    // Update is called once per frame
    void Update()
    {
    	if(isDead)
    	{
    		return;
    	}
    	//plyaer will enter to next level when his score exceeds required score
    	if(score >= scoreToNextLevel)
    	{
    		Levelup();
    	}
    	//score increases as per the difficulty level and time
    	score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }
    void Levelup()
    {
    	if(difficultyLevel == maxDifficultyLevel)
    		return;
    	//required score to reach next level increases two times from existing level score
    	scoreToNextLevel *= 2;
    	//difficulty level also increases when the player reaches scoreToNextLevel
    	difficultyLevel++;
    	//When user reaches another level speed increases
    	GetComponent<bckPlayerMotor>().setSpeed(difficultyLevel);
    	Debug.Log(difficultyLevel);
    }

    public void OnDeath()
    {
    	isDead = true;
    	
    	if(PlayerPrefs.GetFloat("Highestscore") < score)
    	{
    		PlayerPrefs.SetFloat("Highestscore", score);
    	}
    	
    	deathmenu.ToggleEndMenu(score);
    }
}
