//----------------------------------------------------//

//                   Ruscio Agustin                  //

//--------------------------------------------------//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowTime : MonoBehaviour, IItem
{
    [SerializeField]
    private float _timeDiveder;

    [SerializeField]
    private float _timeOnReduce;

    private float _timer;

    private BoxCollider _collider;

    [SerializeField]
    private Text _timerTextUi;

    [SerializeField]
    private Image _image;

    private bool _timerActivated;

    [SerializeField]
    private AudioSource _audioSource;

    private void Awake()
    {
        _collider= GetComponent<BoxCollider>();
        _timerTextUi.gameObject.SetActive(false);
        _image.gameObject.SetActive(false);
        _timer = _timeOnReduce;
    }

    private void Update()
    {
        if (_timerActivated)
        {
            _timer = _timer - 1 * Time.deltaTime;

            if(_timer < 0)
            {
                _timer = 0;
            }

            _timerTextUi.text = _timer.ToString("F2");
        }     
    }

    public void ItemAction(Player player)
    {
        Time.timeScale *= _timeDiveder;

        _timerTextUi.gameObject.SetActive(true);
        _image.gameObject.SetActive(true);
        _timerActivated = true;

        _audioSource.Play();

        StartCoroutine(RestoreTime());
        _collider.enabled= false;
    }

    IEnumerator RestoreTime()
    {
        yield return new WaitForSeconds(_timeOnReduce);

        _timerActivated = true;
        _timerTextUi.gameObject.SetActive(false);


        _image.gameObject.SetActive(false);

        _audioSource.Stop();

        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
