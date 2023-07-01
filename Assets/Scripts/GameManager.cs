using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _returnButton;
    [SerializeField] GameObject _titleButton;
    [SerializeField] GameObject _gameClear;

    [System.NonSerialized] public bool _isGameOver = false;
    [System.NonSerialized] public bool _isGameClear = false;
    [System.NonSerialized] public float _score = 0;
    [System.NonSerialized] public bool _bossDead = false;

    [SerializeField] BossController _bossController;
    [SerializeField] Text _scoreText;
    [SerializeField] GameObject _gameOver;



    void Start()
    {
        _returnButton.SetActive(false);
        _titleButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Text scoreText = FindObjectOfType<Text>();
        
        _scoreText.text = _score.ToString();

        if (_isGameOver)
        {
            StartCoroutine(DelayTime());
        }

        if (_isGameClear)
        {
            _returnButton.SetActive(true);
            _gameClear.SetActive(true);
            print("gameclear");
        }
    }

    public void IsGemeOver()
    {
        _isGameOver = true;
    }

    public void IsGameClear()
    {
        _isGameClear = true;
    }

    public void Return()
    {
        print("return");
        SceneManager.LoadScene("main");
        Time.timeScale = 1.0f;
    }

    public void Title()
    {
        print("title");
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1.0f;
    }

    public IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1f);
        _gameOver.SetActive(true);
        _returnButton.SetActive(true);
        _titleButton.SetActive(true);
        Time.timeScale = 0;

        
    }

    public void ScoreUper()
    {
        if (_bossController._bossEffectEnd == true)
        {
            _score += 10000;
        }
        else
        {
            _score += 1000;
        }
        print(_score);
    }
}
