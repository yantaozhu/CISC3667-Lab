using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] float horizontalMovement;
    [SerializeField] float verticalMovement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] Vector3 scale;
    [SerializeField] AudioSource pop;

    private Transform player;
    private int level;
    private int score;
    private int point;
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(Random.Range(-13,13),Random.Range(-9,9),0);
        level = PersistentData.Instance.GetLevel();
        score = PersistentData.Instance.GetScore();
        horizontalMovement = Random.Range(8f+(3*level),10f+(3*level));
        verticalMovement = Random.Range(8f+(3*level),10f+(3*level));
        time = 1000;
        scale = new Vector3(0.001f, 0.001f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0){
            time--;
            transform.localScale += scale;
        }
        else {
            Destroy(gameObject);
        }
        if (level == 3)
        {
            if(Vector2.Distance(transform.position, player.position) < 5)
            {
                horizontalMovement = -1 * horizontalMovement;
                verticalMovement = -1 * verticalMovement;
            }
        }
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector3(horizontalMovement, verticalMovement, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "XBoundary")
        {
            if (horizontalMovement > 0) {
                horizontalMovement = Random.Range(-8f-(3*level),-10f-(3*level));
            }
            else {
                horizontalMovement = Random.Range(8f+(3*level),10f+(3*level));
            }
            transform.Rotate(0, 180, 0);
            isFacingRight = !isFacingRight;
        }
        if (collision.gameObject.tag == "YBoundary")
        {
            if (verticalMovement > 0) {
                verticalMovement = Random.Range(-8f-(3*level),-10f-(3*level));
            }
            else {
                verticalMovement = Random.Range(8f+(3*level),10f+(3*level));
            }
        }
    }
    
    void OnDestroy () {
        pop.Play();
        if (time > 0)
        {
            point = time;
            wait(3);
            PersistentData.Instance.SetScore(point + score);
            NextLevel();
        }
        else
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
  	    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    void NextLevel()
    {
        level += 1;
        PersistentData.Instance.SetLevel(level);
        if (level > 3) {
            SceneManager.LoadScene("HighScore");
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
