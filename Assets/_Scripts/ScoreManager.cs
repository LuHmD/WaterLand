using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI highScoreText;

    public int scoreCount;
    public int highScoreCount;

    

    public bool multiplePickedUp;
   
    // Start is called before the first frame update
    void Start()
    {
        multiplePickedUp = false;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetInt("HighScore");

        }

    }

    // Update is called once per frame
    void Update()
    {
        

        scoreText.text = "Score: " + scoreCount;

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText1.text = "Score: " + scoreCount;
        highScoreText.text = "HighScore: " + highScoreCount;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag =="multiple")
        {
            multiplePickedUp = true;
            collision.gameObject.SetActive(false);

        }

        if (collision.transform.tag == ("Coin")&& !multiplePickedUp)
        {
            scoreCount += 2;

        }

        if (collision.transform.tag == ("Coin")&& multiplePickedUp)
        {
            scoreCount = 2*3;

        }
    }
}
