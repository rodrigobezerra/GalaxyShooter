using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Monobehavior é a super classe que permite ao Unity adicionar comportamentos a gameObjects do projeto
public class Player : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Name: " + name);
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        // Entrada do eixo horizontal (Edit -> Project Settings -> Input)
        // Negativo: movimentando-se para a esquerda;
        // Zero: objeto parado;
        // Positivo: movimentando-se para a direita;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Time.deltaTime:  é o intervalo de tempo entre um Update e outro
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
    }
}
