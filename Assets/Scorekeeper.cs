using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text levelTxt;
    [SerializeField] int level;

    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        level = PersistentData.Instance.GetLevel();

        //display score
        DisplayScore();
        DisplayLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        int levelToDisplay = level;
        levelTxt.text = "Level: " + levelToDisplay;
    }        
}
