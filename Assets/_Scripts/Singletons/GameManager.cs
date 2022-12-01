using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
//using Cinemachine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameOver;
    public bool isGameStarted;
    public GameObject gameOverScreen;

    public Transform[] coinSpawnLocations;
    public Vector2 lastCheckPointPos = new Vector2(-20, 5);

    internal void GameOver()
    {
        SoundManager.Instance.PlayEffect(FindObjectOfType<PlayerMotor>().
                          playerClips.playerSoundFx[6]);
        isGameOver = true;
    }

    //public GameObject[] playerPrefabs;

    public GameObject playerPrefab;
    public GameObject coinPrefab;
    public Transform playerSpawnPos;
    int characterIndex;

    public int numberOfCoins;
    public TextMeshProUGUI coinsText;

    //private void Awake()
    //{
    //    Instance = this;
    //    PlayerPrefs.DeleteAll(); // for debugging purposes. 
    //    numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
    //    isGameOver = false;
    //    GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;

    //    characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
    //    Instantiate(GameManager.Instance.playerPrefabs[0], lastCheckPointPos, Quaternion.identity); 
    //}

    private void Awake()
    {
        isGameStarted = false;
        Instance = this;
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }
    private void Start()
    {
        if (coinSpawnLocations.Length > 0)
            foreach (var spot in coinSpawnLocations)
            {
                Instantiate(coinPrefab, spot.position, Quaternion.identity);
            }
    }
    private void Update()
    {
        coinsText.text = numberOfCoins.ToString();

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            // call the tweening. 
            FindObjectOfType<TweenUI>().LT_GameOver();
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        isGameStarted = true;
        SoundManager.Instance.PlayEffect(
            FindObjectOfType<PlayerMotor>().playerClips.playerSoundFx[0]);
    }

    internal void LevelComplete()
    {
        isGameStarted = false; 
        FindObjectOfType<TweenUI>().LT_LevelSuccess();
        // add collected coins to the total
        PlayerPrefs.SetInt("Wallet", PlayerPrefs.GetInt("Wallet", 0) + numberOfCoins); 
    }
}
