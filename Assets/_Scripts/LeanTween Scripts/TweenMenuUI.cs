using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMenuUI : MonoBehaviour
{

    [Header("Scaled Objects")]
    public GameObject btn_Setting;
    public GameObject panel_Wallet;
    public GameObject btn_Play;
    public GameObject panel_Services;

    [Header("Slide In Objects")]
    public GameObject panel_Levels;


    private bool canPressPlay = false; 
    void Start()
    {
        ScaleInButtons();         
    }
    public void ScaleInButtons()
    {
        canPressPlay = true; 
        LeanTween.scale(btn_Setting, Vector3.one, 0.5f).setEase(LeanTweenType.easeInCubic);  
        LeanTween.scale(panel_Wallet, Vector3.one, 0.5f).setEase(LeanTweenType.easeInCubic).setDelay(.5f); 
        LeanTween.scale(panel_Services, Vector3.one, 0.5f).setEase(LeanTweenType.easeInCubic).setDelay(.5f);
        LeanTween.scale(btn_Play, Vector3.one, 0.5f).setDelay(1f).setEase(LeanTweenType.easeInCubic).setOnComplete(LoopTweenPlay);  
    }
    private void LoopTweenPlay()
    {
        if (!canPressPlay)
            return; 
        LeanTween.scale(btn_Play, new Vector3(1.1f, 1.1f, 1.1f), .3f); 
        LeanTween.scale(btn_Play, Vector3.one, .3f).setDelay(.3f).setOnComplete(LoopTweenPlay);
    }
    public void ScaleOutButtons()
    {
        canPressPlay = false;
        LeanTween.scale(btn_Setting, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutCubic).setDelay(1f);
        LeanTween.scale(panel_Wallet, Vector3.zero, 0.5f).setEase(LeanTweenType.easeOutCubic).setDelay(.8f);
        LeanTween.scale(panel_Services, Vector3.zero, .5f).setEase(LeanTweenType.easeOutCubic).setDelay(.5f);
        LeanTween.scale(btn_Play, Vector3.zero, 1f).setEase(LeanTweenType.easeOutBounce).setDelay(.2f).setOnComplete(BringInLevel);
    }
    private void BringInLevel()
    {
        panel_Levels.SetActive(true); 
        LeanTween.moveLocalX(panel_Levels, 0, .5f).setEaseInCubic();
    }
    public void TransitToMenu()
    {
        LeanTween.moveLocalX(panel_Levels, 1400, .5f).setEaseOutCubic().setOnComplete(DisablePanel);
        //panel_Levels.SetActive(false);
        ScaleInButtons(); 
    }
    private void DisablePanel()
    {
        panel_Levels.SetActive(false); 
    }
}
