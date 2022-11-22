using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using Cinemachine;


public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;


    public static Vector2 lastCheckPointPos = new Vector2(-25, 12);
    public GameObject[] playerPrefabs;
    int characterIndex;

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
        
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
         Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, Quaternion.identity);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
