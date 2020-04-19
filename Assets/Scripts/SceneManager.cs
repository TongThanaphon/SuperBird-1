using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneManager : MonoBehaviour
{
    public Button play;
    public Button credit;
    public Button option;
    public AudioMixer mixer;
    // Start is called before the first frame updates
    void Start()
    {
        mixer.SetFloat("sfxVol", PlayerPrefs.GetFloat("SFX"));
        mixer.SetFloat("bgVol", PlayerPrefs.GetFloat("Bg"));
        mixer.SetFloat("masterVol", PlayerPrefs.GetFloat("Master"));
        play.onClick.AddListener(delegate{ChangeScene("Main");});
        credit.onClick.AddListener(delegate{ChangeScene("Credit");});
        option.onClick.AddListener(delegate{ChangeScene("Option");});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScene(string scene){
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
