using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]
    private float _speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player"))
        {
            // access the player
            Player player = other.GetComponent<Player>();

            if (player)
            {
                // enable tripple shoot
                player.TrippleShootPowerupOn();                
            }

            // destroy ourself
            Destroy(this.gameObject);
        }
    }
    
}
