using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{

    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    [SerializeField] int level;
    [SerializeField] float backgroundVolume;
    [SerializeField] AudioSource background;
    
    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<AudioSource>();
        playerScore = 0;
        playerName = "";
        level = 0;
        backgroundVolume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        background.volume = backgroundVolume;
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void SetLevel(int lv)
    {
        level = lv;
    }

    public int GetLevel()
    {
        return level;
    }
    public float GetVolume()
    {
        return backgroundVolume;
    }
    public void SetVolume(float vol)
    {
        backgroundVolume = vol;
    }
}
