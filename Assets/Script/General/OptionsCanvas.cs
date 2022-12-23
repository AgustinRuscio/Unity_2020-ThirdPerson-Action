//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Audio;
using Newtonsoft.Json.Linq;

public class OptionsCanvas : MonoBehaviour
{
    [SerializeField]
    private Slider senSlider;

    [SerializeField]
    private Slider masterSlider;

    [SerializeField]
    private Slider musicSlider;

    [SerializeField]
    private Slider fxSlider;

    [SerializeField]
    private Slider enviSlider;

    public event Action changeSens;

    [SerializeField]
    private AudioMixer _master;

    private void Start()
    {
        senSlider.value = PlayerPrefs.GetFloat("sensitivity");


        masterSlider.value = PlayerPrefs.GetFloat("masterVol");
        _master.SetFloat("Master", Mathf.Log(masterSlider.value) * 20);


        musicSlider.value = PlayerPrefs.GetFloat("musicVol");
        _master.SetFloat("Music", Mathf.Log(musicSlider.value) * 20);


        fxSlider.value = PlayerPrefs.GetFloat("fxVol");
        _master.SetFloat("Fx", Mathf.Log(fxSlider.value) * 20);


        enviSlider.value = PlayerPrefs.GetFloat("enviVol");
        _master.SetFloat("Enviroment", Mathf.Log(enviSlider.value) * 20);
    }

    public void SetSensitivity()
    {
        PlayerPrefs.SetFloat("sensitivity", senSlider.value);
        changeSens?.Invoke();
    }

    public void changeMusicVolumen(float value)
    {
        float log = 0f;

        log = Mathf.Log(value) * 20;
        _master.SetFloat("Music", log);

        PlayerPrefs.SetFloat("musicVol", value);
    }

    public void changeFxVolumen(float value)
    {
        float log = 0f;

        log = Mathf.Log(value) * 20;
        _master.SetFloat("Fx", log);

        PlayerPrefs.SetFloat("fxVol", value);
    }

    public void changeEnviromentVolumen(float value)
    {
        float log = 0f;

        log = Mathf.Log(value) * 20;
        _master.SetFloat("Enviroment", log);

        PlayerPrefs.SetFloat("enviVol", value);
    }

    public void changeMasterVolumen(float value)
    {
        float log = 0f;

        log = Mathf.Log(value) * 20;
        _master.SetFloat("Master", log);

        PlayerPrefs.SetFloat("masterVol", value);
    }
}
