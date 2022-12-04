using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using Cinemachine;


public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;


    public static Vector2 lastCheckPointPos ;
    public GameObject[] playerPrefabs;
    int characterIndex;

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private ScoreManager theScoreManager;

    private void Awake()
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
        
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        
        coinsText.text =  numberOfCoins.ToString();

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
       // theScoreManager.scoreIncreasing = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

       // theScoreManager.scoreIncreasing = true;
    }
}
