using UnityEngine;
using PathCreation;

public class Controller : MonoBehaviour
{
    public PathCreator pathCreator;  // Ссылка на компонент PathCreator с вашей дорогой
    public float speed = 5f;         // Скорость машины
    private float distanceTravelled; // Пройденное расстояние по пути
    private bool isMoving = false;

    void Awake()
    {
        // Если в инспекторе поле не заполнено, ищем первый объект с PathCreator в сцене
        if (pathCreator == null)
        {
            pathCreator = GameObject.FindObjectOfType<PathCreator>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving; // Переключение состояния движения при нажатии пробела
        }

        if (isMoving && pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            Vector3 newPos = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Loop);
            Quaternion newRot = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Loop);

            transform.position = newPos;
            transform.rotation = newRot;
        }
    }
}
