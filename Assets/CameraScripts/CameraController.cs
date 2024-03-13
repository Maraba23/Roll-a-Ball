using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 5.0f; // Ajuste para tornar a rotação mais rápida ou mais lenta

    private float mouseX;

    void Start()
    {
        transform.position = player.transform.position;
        // Bloqueia o cursor no centro da tela e o torna invisível
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Obtém o movimento horizontal do mouse e multiplica pela velocidade de rotação
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;

        // Aplica a rotação ao redor do eixo Y
        transform.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    void LateUpdate()
    {
        // Mantém a câmera na posição do jogador, mas não altera sua rotação aqui
        transform.position = player.transform.position;
    }
}
