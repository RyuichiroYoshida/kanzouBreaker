using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BossController : MonoBehaviour
{
    [SerializeField] public int _bossLife = 100;
    [SerializeField] BossEffect _effect;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _enemySpawnCoolTime = 3;

    int _bulletsCounts = 0;
    int _enemyCounts = 0;
    float timer = 0;
    float bulletTimer = 0;

    [System.NonSerialized] public bool _bossEffectEnd = false;

    [SerializeField] GameManager _gameManager;
    [SerializeField] PlayerController _playerController;
    [SerializeField] GameObject _enemyBulletPrefab;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _deadImage;

    void Start()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;
        bulletTimer += Time.deltaTime;

        if (_bossEffectEnd == true)
        {
            _gameManager.ScoreUper();
            _gameManager.IsGameClear();
            Destroy(this.gameObject);
        }

        if (_effect._bossArrive == true && _effect._bossDead != true)
        { 
            float x = transform.position.x - _playerTransform.position.x;

            if (x < 10)
            {
                transform.position += new Vector3(Time.deltaTime * 2, 0, 0);
            }

            _bulletsCounts++;
            if (_bulletsCounts <= 7)
            {

            }

            _enemyCounts += 2;
            if (_enemyCounts <= 50)
            {
                if (timer > 1)
                {
                    StartCoroutine(SpawnDelayTime());
                    /*
                    float enemyY = this.gameObject.transform.position.y + 3;
                    Instantiate(_enemyPrefab, new Vector3(this.gameObject.transform.position.x, enemyY, this.gameObject.transform.position.z), Quaternion.identity);
                    print("countNow");
                    float enemyY2 = this.gameObject.transform.position.y - 3;
                    Instantiate(_enemyPrefab, new Vector3(this.gameObject.transform.position.x, enemyY2, this.gameObject.transform.position.z), Quaternion.identity);
                    */
                    timer = 0;
                }
                _enemyCounts = 0;
            }
            if (bulletTimer > 0.5)
            {
                float y = Random.Range(-3, 3);
                Instantiate(_enemyBulletPrefab, new Vector3(transform.position.x, y, transform.position.z), Quaternion.Euler(0, 0, 90f));
                bulletTimer = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _bossLife--;
            print(_bossLife);
            _effect._bossArrive = true;
            if (_bossLife <= 0)
            {
                _deadImage.SetActive(true);
                _playerController._bulletCoolTime = 1000;
                _gameManager._bossDead = true;
                _effect._bossDead = true;
            }
        }
    }

    IEnumerator SpawnDelayTime()
    {
        print("delay1");
        float random1 = Random.Range(0, 7);
        float enemyY = this.gameObject.transform.position.y + random1;
        Instantiate(_enemyPrefab, new Vector3(this.gameObject.transform.position.x, enemyY, this.gameObject.transform.position.z), Quaternion.identity);

        yield return new WaitForSeconds(_enemySpawnCoolTime);

        float random2 = Random.Range(0, -7);
        float enemyY2 = this.gameObject.transform.position.y - random2;
        Instantiate(_enemyPrefab, new Vector3(this.gameObject.transform.position.x, enemyY2, this.gameObject.transform.position.z), Quaternion.identity);
        print("delay2");
        
    }
}
