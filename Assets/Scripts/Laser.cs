using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move up at a certain speed 
        transform.Translate(_speed * Time.deltaTime * Vector3.up);
        if (transform.position.y >= 6.0f) {
            Destroy(this.gameObject);
        }
    }
}
