using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenUI : MonoBehaviour
{
    [Header("Game Over Panel")]
    public GameObject _panelGameOver;
    public GameObject _btnRetry;
    public GameObject _btnGoHome;

    [Header("Level Success Panel")]
    public GameObject _panelSuccess;

    // LeanTween Gameover. 
    internal void LT_GameOver()
    {
        _panelGameOver.SetActive(true);
        LeanTween.moveLocalY(_panelGameOver, 0f, 0.2f);  
        LeanTween.scale(_btnRetry, Vector3.one, 0.3f).setDelay(.2f);
        LeanTween.scale(_btnGoHome, Vector3.one, 0.4f).setDelay(0.5f); 
    }

    internal void LT_LevelSuccess()
    {
        _panelSuccess.SetActive(true);
        LeanTween.moveLocalY(_panelSuccess, 0f, 0.2f); 
        // Tween the remain properties of the Panel appropriately. 
    }
}
