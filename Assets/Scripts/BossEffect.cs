using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossEffect : MonoBehaviour
{
    [SerializeField] GameObject _effectPrefab;
    [SerializeField] BossController _controller;
    [SerializeField] Transform _transform;
    [System.NonSerialized] public bool _bossArrive = false;
    [System.NonSerialized] public bool _bossDead = false;
    int count = 0;
    float timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_bossArrive == true)
        {
            timer += Time.deltaTime;
            _transform = gameObject.transform;
            if (_bossDead == true)
            {
                if (timer > 0.1)
                {
                    count++;

                    Vector3 localPos = this.gameObject.transform.position;
                    float effectPointX = Random.Range(-1.5f, 1.5f);
                    float effectPointY = Random.Range(-5f, 5f);
                    float x = 0;
                    float y = 0;
                    x = localPos.x + effectPointX;
                    y = localPos.y + effectPointY;
                    Instantiate(_effectPrefab, new Vector3(x, y, 1), Quaternion.identity);
                    timer = 0f;

                }
                if (count == 50)
                {
                    _controller._bossEffectEnd = true;
                }
            }
        }
    }
}
