using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItween : MonoBehaviour
{
    [SerializeField] GameObject wholePanel, coinPanel, replayButton, nextButton, homeButton,
        star1, star2, star3, levelSuccess;
    
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(levelSuccess, new Vector3(1.0f, 1.0f, 1.0f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(LevelComplete);
        LeanTween.moveLocal(levelSuccess, new Vector3(0, 400f, 0), .7f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);    
        LeanTween.scale(levelSuccess, new Vector3(1.0f, 1.0f, 1.0f), .2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);    
    }
    void LevelComplete()
    {
       
        LeanTween.moveLocal(wholePanel, new Vector3(0, 7f, 0), 0.7f).setDelay(0.5f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(StarsAnim);
        LeanTween.scale(homeButton, new Vector3(1.0f, 1.0f, 1.0f), .2f).setDelay(0.7f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(replayButton, new Vector3(1.0f, 1.0f, 1.0f), .2f).setDelay(0.8f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(nextButton, new Vector3(1.0f, 1.0f, 1.0f), .2f).setDelay(0.9f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.alpha(coinPanel.GetComponent<RectTransform>(), 1f, 0.5f).setDelay(1f);}
    
    void StarsAnim()
    {
        LeanTween.scale(star1, new Vector3(1.0f, 1.0f, 2.0f), .2f).setEase(LeanTweenType.easeOutElastic);
        LeanTween.scale(star2, new Vector3(1.5f, 1.5f, 1.8f), .2f).setDelay(0.1f).setEase(LeanTweenType.easeInOutElastic);
        LeanTween.scale(star3, new Vector3(1.0f, 1.0f, 2.0f), .2f).setDelay(0.2f).setEase(LeanTweenType.easeInOutElastic);

    }
}
