using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionManager : MonoBehaviour
{
    public Button confirm;
    public Button cancel;
    public AudioMixer mixer;
    public Slider sliderSFX;
    public Slider sliderBg;
    public Slider sliderMaster;
    private int check;
    void Start()
    {
        check = 0;
        if(PlayerPrefs.HasKey("SFX")){
            sliderSFX.value = PlayerPrefs.GetFloat("SFX"); 
        }else{
            PlayerPrefs.SetFloat("SFX", sliderSFX.value);
        }
        if(PlayerPrefs.HasKey("Bg")){
            sliderBg.value = PlayerPrefs.GetFloat("Bg"); 
        }else{
            PlayerPrefs.SetFloat("Bg", sliderBg.value);
        }
        if(PlayerPrefs.HasKey("Master")){
            sliderMaster.value = PlayerPrefs.GetFloat("Master"); 
        }else{
            PlayerPrefs.SetFloat("Master", sliderMaster.value);
        }
        confirm.onClick.AddListener(delegate{Confirm();});
        cancel.onClick.AddListener(delegate{Cancel();});
    }

    private void Update() {
        if(check == 0){
            mixer.SetFloat("sfxVol", sliderSFX.value);
            mixer.SetFloat("bgVol", sliderBg.value);
            mixer.SetFloat("masterVol", sliderMaster.value);
        }
    }
    public void Confirm(){
        PlayerPrefs.SetFloat("SFX", sliderSFX.value);
        PlayerPrefs.SetFloat("Bg", sliderBg.value);
        PlayerPrefs.SetFloat("Master", sliderMaster.value);
        PlayerPrefs.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Landing", LoadSceneMode.Single);
    }
    public void Cancel(){
        check = 1;
        mixer.SetFloat("sfxVol", PlayerPrefs.GetFloat("SFX"));
        mixer.SetFloat("bgVol", PlayerPrefs.GetFloat("Bg"));
        mixer.SetFloat("masterVol", PlayerPrefs.GetFloat("Master"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Landing", LoadSceneMode.Single);
    }
}
