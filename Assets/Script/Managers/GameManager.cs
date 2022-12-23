//----------------------------------------------------//

// Ruscio Agustin       &&      Riego Maria Mercedes //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int _resetLife = 3;

    public float timer;

    [SerializeField]
    private Text _timerVariableText;

    [SerializeField]
    private Text _timerTxt;

    private Action _activarTimer;

    public LevelDetection _gameStatus;

    [SerializeField]
    private Transform _keySpawnPoint;

    [SerializeField]
    private Transform _alternativeSpawnPoint;

    [SerializeField]
    private GameObject _keyObject;

    private int _initialKeys;

    [SerializeField]
    private GameObject _alterantiveItem;

    [SerializeField]
    private Door _door;

    private string lvl;

    [SerializeField]
    private SoundData _sound;

    private void Awake()
    {
        if(instance == null)
            instance = this;

        _timerVariableText.gameObject.SetActive(false);
        _timerTxt.gameObject.SetActive(false);

        lvl = GameData.saveLvl(SceneManager.GetActiveScene().name);

        _gameStatus = GameData.GetLvlEnum(lvl);

        switch (_gameStatus)
        {
            case LevelDetection.Menu:
                IfMainMenu();
                break;

            case LevelDetection.Level:
                IfLevel();
                break;

            case LevelDetection.Tutorial:
                IfTutorial();
                break;
        }
    }

    void Start()
    {
        timer = 0;
        Time.timeScale = 1f;

        _initialKeys = KeysManager.instance.keysCount;
    }

     void FixedUpdate()
     {
        _activarTimer();
     }
            
    void levelTimer()
    {
        timer = timer + 1 * Time.deltaTime;
        _timerVariableText.text = timer.ToString("0") + " s";
    }

    void IfMainMenu()
    {
        _activarTimer = delegate { };
    }

    void IfTutorial()
    {
        _activarTimer = delegate { };
        AudioManager.instance.AudioPlay(_sound, _door.transform.position);

        if (_door._keysRequiere > KeysManager.instance.keysCount)
            Instantiate(_keyObject, _keySpawnPoint);     
    }
    void IfLevel()
    {
        _activarTimer = levelTimer;

        _timerVariableText.gameObject.SetActive(true);
        _timerTxt.gameObject.SetActive(true);

        if (_door._keysRequiere > KeysManager.instance.keysCount)
            Instantiate(_keyObject, _keySpawnPoint);    
        else
        {
            _door.gameObject.SetActive(false);
            float randomSpawn = UnityEngine.Random.Range(0,101);

            if(randomSpawn <= 80)        
                Instantiate(_alterantiveItem, _alternativeSpawnPoint);
            else
                Instantiate(_alterantiveItem, _keySpawnPoint);
        }
    }

    public void Death()
    {
        SpawnsManager.instance.lifes = _resetLife;
        KeysManager.instance.keysCount = _initialKeys;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("LoseScene");
    }

    public void reduceTimer(float reducer)
    {
        timer -= reducer;

        if (timer < 0)
            timer = 0;
    }
}

    public enum LevelDetection
    { 
        Menu,
        Level,
        Tutorial,
    }