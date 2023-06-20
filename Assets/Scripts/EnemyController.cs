using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int _enemyLife = 2;
    public float _enemySpeed = 5f;
    public GameObject _player;

    [SerializeField] GameManager _gameManager;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _gameManager = GameManager.FindAnyObjectByType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _enemySpeed * Time.deltaTime);
        }
        if (_gameManager._bossDead == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _enemyLife--;
            print(_enemyLife);
            if (_enemyLife <= 0)
            {
                _gameManager.ScoreUper();

                Destroy(this.gameObject);
            }
        }
    }
}
