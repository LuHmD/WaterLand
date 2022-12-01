using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenText : MonoBehaviour
{
    // we get the text string, then one by one we animate them in a certain direction
    // the direction will be specified by enums, but for now let's just use left. 

    public GameObject _paneltextField; 
    [SerializeField, Tooltip("String to Animated")]
    private string _textString;
    [SerializeField, Tooltip("The Area to put the animated Text")]
    private TMPro.TextMeshProUGUI TextField;
    private void Start()
    {
        StartCoroutine(TweenTextLeft(_textString));
    }
    IEnumerator TweenTextLeft(string textString)
    {
        var _charArray = textString.ToCharArray();
        foreach (var _character in _charArray)
        {
            TextField.text += _character;
            yield return new WaitForSeconds(.05f); 
        }
        LT_PanelText(); 
    }

    private void LT_PanelText()
    {
        LeanTween.moveLocalX(_paneltextField, -30f, .5f); 
        LeanTween.moveLocalX(_paneltextField, 30f, .5f).setDelay(.5f).setOnComplete(LT_PanelText); 
    }


}
