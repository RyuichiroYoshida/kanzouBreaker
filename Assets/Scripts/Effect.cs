using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this, 10f);
    }
}
