using UnityEngine;
using Unity.Cinemachine;


public class WagonController : MonoBehaviour
{
    public CinemachineSplineCart splineCart;
    public TrainController trainController;
    public float offset = 0.1f;
    public float followSpeed = 2f; // скорость "догон€ни€" локомотива

    private float currentPosition;

    void Start()
    {
        currentPosition = trainController.Position - offset;
        if (currentPosition < 0) currentPosition += 1f;
    }

    void Update()
    {
        float targetPosition = trainController.Position - offset;
        if (targetPosition < 0) targetPosition += 1f;

        // ѕлавное приближение currentPosition к targetPosition
        currentPosition = Mathf.Lerp(currentPosition, targetPosition, Time.deltaTime * followSpeed);

        splineCart.SplinePosition = currentPosition;
    }
}

//public class WagonController : MonoBehaviour
//{
//    public CinemachineSplineCart splineCart;
//    public TrainController trainController; // ссылка на главный скрипт локомотива
//    public float offset = 0.1f; // отставание по позиции

//    void Update()
//    {
//        float newPosition = trainController.Position - offset;
//        if (newPosition < 0) newPosition += 1f; // цикл по замкнутому сплайну
//        splineCart.SplinePosition = newPosition;
//    }
//}

