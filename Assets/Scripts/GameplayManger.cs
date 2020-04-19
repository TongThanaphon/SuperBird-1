using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameplayManger : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;
    public Text currentText;
    public Text bestText;
    public Button playAgain;
    public Button home;
    public Button reset;
    public GameObject player; 
    public GameObject countDown;
    public Text timer;
    public GameObject firstDummy;
    public GameObject spawner;
    public int countDownTime;   
    public SoundManager soundManager;
    public float speed;
    private int time;
    private int check = 1;
    private int spawnTime;
    private int score;
    void Awake()
    {
        InvokeRepeating("CountDown", 0, 1);
        Invoke("StartGame",countDownTime);
        spawnTime = spawner.GetComponent<Spawner>().GetSpawnTime();
        soundManager = FindObjectOfType<SoundManager>();
        score = 0;
        home.onClick.AddListener(delegate{  
            UnityEngine.SceneManagement.SceneManager.LoadScene("Landing", LoadSceneMode.Single);
        });
        playAgain.onClick.AddListener(delegate{  
            UnityEngine.SceneManagement.SceneManager.LoadScene("Main", LoadSceneMode.Single);
        });
        reset.onClick.AddListener(delegate{  
            PlayerPrefs.SetInt("Best",0);
            bestText.text = "Highest Score: " + PlayerPrefs.GetInt("Best").ToString();
            reset.gameObject.SetActive(false);
        });
    }
    void Update()
    {
        if(score%10 == 0 && check == 0){
            check = 1;
            firstDummy.SetActive(true);
            firstDummy.transform.position = new Vector3(0, spawner.GetComponent<Spawner>().Getlast(), 0);
            player.gameObject.transform.position = new Vector3(player.transform.position.x-(spawnTime*10), player.gameObject.transform.position.y, 0);
            spawner.GetComponent<Spawner>().Shuffle(1);
        }
        if(score%10 == 2 && check == 1){
            check = 0;
            spawner.GetComponent<Spawner>().Shuffle(2);
        }
    }
    public void CountDown(){
        timer.text = countDownTime.ToString();
        countDownTime--;
        if(countDownTime == 0){
            CancelInvoke("CountDown");
        }
    }
    public void StartGame(){
        countDown.SetActive(false);
        scoreText.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().SetSpeed(speed);
        player.GetComponent<PlayerController>().Init();
    }
    public void gameOver(){
        soundManager.Play("dead");
        soundManager.Stop("bg");
        gameOverPanel.gameObject.SetActive(true);
        currentText.text = "Current Score: " + score.ToString();
        if(PlayerPrefs.HasKey("Best")){
            if(PlayerPrefs.GetInt("Best") < score){
                PlayerPrefs.SetInt("Best",score);
            }
        }else{
            PlayerPrefs.SetInt("Best",score);
        }
        bestText.text = "Highest Score: " + PlayerPrefs.GetInt("Best").ToString();
    }
    public void addScore(){
        score += 1;
        scoreText.text = score.ToString();
        soundManager.Play("score");
    }
}
