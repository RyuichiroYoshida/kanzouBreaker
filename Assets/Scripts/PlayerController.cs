using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] public float _bulletCoolTime = 2;

    float _nomalBulletTime = 0;


    public GameManager _gameManager;
   // public PlayerShield _playerShield;

    [SerializeField] GameObject _effectPrefab;
    void Start()
    {
        
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * _speed;


        _nomalBulletTime += Time.deltaTime;

        Vector3 localPos = transform.localPosition;
        localPos.x += 3;
        if (_nomalBulletTime > _bulletCoolTime)
        {
            Instantiate(_bulletPrefab, new Vector3(localPos.x, localPos.y, localPos.z), Quaternion.identity);
            Instantiate(_bulletPrefab, new Vector3(localPos.x, localPos.y - 1, localPos.z), Quaternion.identity);
            Instantiate(_bulletPrefab, new Vector3(localPos.x, localPos.y + 1, localPos.z), Quaternion.identity);
            _nomalBulletTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {    
                PlayerEffect();

                _gameManager.IsGemeOver();

                Destroy(this.gameObject);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            PlayerEffect();

            _gameManager.IsGemeOver();

            Destroy(this.gameObject);

        }
    }

    public void PlayerEffect()
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
    }
}
