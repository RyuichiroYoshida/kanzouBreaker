using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleChanger : MonoBehaviour
{
    [SerializeField] GameObject[] _images;
    [SerializeField] GameObject _button;
    
    public static bool _gameReturn = false;

    void Start()
    {
        TitleStart();
    }

    void Update()
    {
        if (_gameReturn == true)
        {
            //StartCoroutine(enumerator());
            _gameReturn = false;
        }
    }

    public void Onclick()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadScene());
    }

     IEnumerator StartTitle()
    {
        _images[0].SetActive(true);
        yield return new WaitForSeconds(1);
        _images[1].SetActive(true);
        yield return new WaitForSeconds(1);
        _images[2].SetActive(true);
        _button.SetActive(true);
    }

    IEnumerator LoadScene()
    {
        _button.SetActive(false);
        _images[3].SetActive(true);
        yield return new WaitForSeconds(1);
        _images[4].SetActive(true);
        yield return new WaitForSeconds(1);
        _images[1].SetActive(false);
        _images[2].SetActive(false);
        _button.SetActive(false);
        _images[3].SetActive(false);
        _images[4].SetActive(false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("main");
    }

    public void TitleStart()
    {
        _images[1].SetActive(false);
        _images[2].SetActive(false);
        _button.SetActive(false);

        _images[3].SetActive(false);
        _images[4].SetActive(false);
        StartCoroutine(StartTitle());
    }

    public static void Starts()
    {
    
    }

}
