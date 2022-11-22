using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{

    public Slider soundSlider;
    public Slider musicSlider;
    public AudioMixer mixer;
    private float soundValue;
    private float musicValue;
    private void Start()
    {
         mixer.GetFloat("volume", out soundValue);
         soundSlider.value = soundValue;
         mixer.GetFloat("volume", out musicValue);
        musicSlider.value = musicValue;
    }
    public void SetVolume()
    {
        mixer.SetFloat("volume", soundSlider.value);
        mixer.SetFloat("volume", musicSlider.value);
    }

    /*public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }*/
}
