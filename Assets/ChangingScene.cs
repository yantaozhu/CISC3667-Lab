using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingScene : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToSetting()
    {
        SceneManager.LoadScene("Setting");
    }
    public void GoToHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }
    public void GoToInstruction()
    {
        SceneManager.LoadScene("Instruction");
    }
}
