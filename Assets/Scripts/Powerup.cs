using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]
    private float _speed = 2.0f;
    
    [SerializeField]
    private int _powerupID; // {0} tripple shoot {1} speed boost {2} shields
    
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
                if (_powerupID == 0)
                    player.TrippleShootPowerupOn();

                // enable speed boost here
                if (_powerupID == 1)
                {
                    player.SpeedBoostPowerupOn();
                }

                // enable shield poweup
                if (_powerupID == 2)
                {

                }

            }

            // destroy ourself
            Destroy(this.gameObject);
        }
    }
}
