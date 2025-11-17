using Unity.Cinemachine;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    public CinemachineSplineCart splineCart;
    public float speed = 5f;
    private bool isMoving = false;
    private float position = 0f;

    // Публичное свойство для доступа к позиции из других скриптов
    public float Position
    {
        get { return position; }
    }
    void Update()
    {
        // Используем старый Input, при необходимости адаптируйте под новую систему ввода
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
        }

        if (isMoving)
        {
            position += speed * Time.deltaTime;
            // Если значение position превысит 1 (нормализованное значение), обнуляем (замкнутый путь)
            if (position > 1f) position -= 1f;

            splineCart.SplinePosition = position;
        }
    }
}


