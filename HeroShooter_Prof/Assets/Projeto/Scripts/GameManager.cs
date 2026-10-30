using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI gameStartText;
    public float startTime = 3f;
    public bool StopCountDown;

    public GameObject tabPanel;
    public int FragScore = 0;
    public int DeathScore = 0;
    public TextMeshProUGUI fragText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI playerNameText;
     public GameObject player;
    public Transform spawnPoint;

   
    void Start()
    {
        StopCountDown = false;
        startTime = 3; 
    }
     void Update()
    {
        ScorePanel();
        StartCountdown();
    }
    void StartCountdown()
    {
        gameStartText.gameObject.SetActive(true);
        if (startTime > 0 && !StopCountDown)
        {
            startTime -= Time.deltaTime;
            gameStartText.text = "Game starts in: " + startTime.ToString("0");
        }
        if (startTime < 0 && !StopCountDown)
        {
            gameStartText.text = "Game Started!";
            Invoke("ClearCountdown", 1f);
        }
    }
    void ClearCountdown()
    {
        gameStartText.text = "";
        gameStartText.gameObject.SetActive(false);
    }

    void ScorePanel()
    {
        if (Keyboard.current[Key.Tab].wasPressedThisFrame)
        {
            tabPanel.SetActive(!tabPanel.activeSelf);
        }
  
    }
    public void UpdateFragScore(int frag)
    {
        FragScore += frag;
        fragText.text = FragScore.ToString();
    }
    public void UpdateDeathScore(int death)
    {
        DeathScore += death;
        deathText.text = DeathScore.ToString();
    }
    public void PlayerLists(string playerName)
    {
        playerNameText.text = playerName;
    }
     public void RespawnPlayer()
    {
        player.transform.position = spawnPoint.position;
        player.SetActive(true);
    }

}
