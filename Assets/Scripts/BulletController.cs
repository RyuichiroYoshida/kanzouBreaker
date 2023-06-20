using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f;
    [SerializeField] float _lifeTime = 7;
    float _time = 0;

    [SerializeField] GameObject _effectPrefab;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * _bulletSpeed;

        if (_time > _lifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
