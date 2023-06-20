using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : MonoBehaviour
{
    [SerializeField] float _gameSpeed = 5f;

    [SerializeField] GameManager _manager;
    [SerializeField] PlayerController _playerController;
    [SerializeField] BossEffect _effect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_effect._bossDead != true)
        {
            transform.position += new Vector3(Time.deltaTime * _gameSpeed, 0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            _playerController.PlayerEffect();

            _manager.IsGemeOver();

            Destroy(collision.gameObject);
        }
    }
}
