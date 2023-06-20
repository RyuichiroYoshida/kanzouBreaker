using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] GameObject _effectPrefab;

    [SerializeField] float _enemyBulletSpeed = 10;
    [SerializeField] float _enemyBulletLifeTime = 7f;

    float _time = 0;
    void Start()
    {
        
    }

    void Update()
    {
        _time += Time.deltaTime;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * _enemyBulletSpeed;

        if (_time > _enemyBulletLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
    }
}
