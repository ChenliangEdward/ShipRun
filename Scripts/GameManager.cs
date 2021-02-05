using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    static public GameManager gm;

    public int TargetScore = 5;        

    public enum GameState             
    { Playing, GameOver };
    public GameState gameState;
    public GameObject player;       

    public GameObject playingCanvas;	//the UI displayed when the game is in progress
    public Text timeText;               //the time displayed on UI
    public Text result;                 //the time text that will appear when the game is over
    public Slider healthSlider;			//a slider to display the player's health
    public GameObject gameResultCanvas;         //游戏结果Canvas
    private ShipProperty shipProperty;

    private int currentScore;           //当前得分
    private float startTime;            //场景加载的时刻
    private float currentTime;          //从场景加载到现在所花的时间
    private bool cursor;                    //鼠标光标是否显示
 
    private bool isGameOver = false;		//标识，保证游戏结束时的相关行为只执行一次

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //禁用鼠标光标
        if (gm == null)         //静态游戏管理器初始化
            gm = GetComponent<GameManager>();
        if (player == null)     //获取场景中的游戏主角
            player = GameObject.FindGameObjectWithTag("Player");
        gm.gameState = GameState.Playing;   //游戏状态设置为游戏进行中
        currentScore = 0;                   //当前得分初始化为0
        startTime = Time.time;              //记录场景加载的时刻 
        shipProperty = player.GetComponent<ShipProperty>(); //获取玩家生命值组件，并初始化玩家生命值与HealthSlider参数
        currentScore = 0;                   //当前得分初始化为0
        shipProperty = player.GetComponent<ShipProperty>();
        if (shipProperty)
        {
            healthSlider.maxValue = shipProperty.startShipHealth;
            healthSlider.minValue = 0;
            healthSlider.value = shipProperty.startShipHealth;
        }
        playingCanvas.SetActive(true);      //启用游戏进行中Canvas
        gameResultCanvas.SetActive(false);	//禁用游戏结果Canvas
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
                if (Input.GetKeyDown(KeyCode.Escape))  // switch cursor visible/not
                    Cursor.visible = !Cursor.visible;
                if (shipProperty.isDead == true)
                    gm.gameState = GameState.GameOver;
                else
                {
                    healthSlider.value = gm.shipProperty.currentShipHealth;
                    currentTime = Time.time - startTime;
                    timeText.text = "Time:" + currentTime.ToString("0.00");
                }
                break;

            case GameState.GameOver:
                Cursor.visible = true;                  //将鼠标光标显示
                playingCanvas.SetActive(false);     //禁用游戏进行中Canvas
                gameResultCanvas.SetActive(true);		//启用游戏结果Canvas
                result.text = "Time:" + currentTime.ToString("0.00") + "s";
                break;
        }
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("GamePlay");
    }
    //加载游戏开始场景
    public void BackToMain()
    {
        SceneManager.LoadScene("GameStart");
    }
}
