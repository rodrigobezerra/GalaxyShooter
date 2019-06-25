using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Monobehavior é a super classe que permite ao Unity adicionar comportamentos a gameObjects do projeto
public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {      
        Movements();   
    }

    private void Movements() {
        // Entrada do eixo horizontal (Edit -> Project Settings -> Input)
        // Negativo: movimentando-se para a esquerda;
        // Zero: objeto parado;
        // Positivo: movimentando-se para a direita;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Time.deltaTime:  é o intervalo de tempo entre um Update e outro
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);

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
