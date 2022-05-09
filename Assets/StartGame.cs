using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] InputField input;
    [SerializeField] Button gameButton;
    [SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
        level = PersistentData.Instance.GetLevel();
        string pName = PersistentData.Instance.GetName();
        if (pName != "" && level > 0 && level <= 3)
            input.placeholder.GetComponent<Text>().text = pName;
        if (level > 0 && level <= 3)
            gameButton.GetComponentInChildren<Text>().text = "Resume game";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        if (level > 0 && level <= 3)
        {
            SceneManager.LoadScene("Level" + level);
            Time.timeScale = 1f;
        }
        else
        {
            string playerName = input.text;
            PersistentData.Instance.SetName(playerName);
            PersistentData.Instance.SetScore(0);
            PersistentData.Instance.SetLevel(1);
            SceneManager.LoadScene("Level1");
        }
    }

}
