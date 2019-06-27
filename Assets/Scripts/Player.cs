using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Monobehavior é a super classe que permite ao Unity adicionar comportamentos a gameObjects do projeto
public class Player : MonoBehaviour
{
    
    [SerializeField]
    private bool canTrippleShoot = false;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _trippleShootPrefab;

    [SerializeField]
    private float _speed = 5.0f;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {      
        Movements(); 

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) {
            Shoot();          
        } 

    }

    private void Shoot()
    {
        // Spawn my laser
        // Quaternion.identity: No rotation or default rotation
        if (Time.time > _canFire)
        {
            if (canTrippleShoot){
                Instantiate(_trippleShootPrefab, transform.position + new Vector3(0f, 0.88f, 0f), Quaternion.identity); 
            } else {
                 Instantiate(_laserPrefab, transform.position + new Vector3(0f, 0.88f, 0f), Quaternion.identity);
            }
             _canFire = Time.time + _fireRate; 
        }
       
    }

    private void Movements() {
        // Entrada do eixo horizontal (Edit -> Project Settings -> Input)
        // Negativo: movimentando-se para a esquerda;
        // Zero: objeto parado;
        // Positivo: movimentando-se para a direita;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Time.deltaTime:  é o intervalo de tempo entre um Update e outro
        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);

        // Y BOUNDARIES 
        if (transform.position.y > 0) 
        {
            transform.position = new Vector3(transform.position.x, 0.0f, 0.0f); 
        } 
        else if(transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0.0f); 
        } 
        // X BOUNDARIES - WRAPPING MODE
        if (transform.position.x < -9.5f) 
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0.0f); 
        } 
        else if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0.0f);
        }      
        
        // if (transform.position.x < -8.5f) 
        // {
        //     transform.position = new Vector3(-8.5f, transform.position.y, 0.0f); 
        // } 
        // else if (transform.position.x > 8.5f)
        // {
        //     transform.position = new Vector3(8.5f, transform.position.y, 0.0f);
        // }            
    }
}
