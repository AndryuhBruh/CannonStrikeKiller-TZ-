using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Обязательно (Остальное можно не устанавливать если нет галочки)")]
    [SerializeField] GameObject platformObject;

    [Header("Передвижение")]
    [SerializeField] bool isMoving;   
    [SerializeField] Transform Point_One;
    [SerializeField] Transform Point_Two;
    [SerializeField] float MovingSpeed;

    [Header("Вращение")]
    [SerializeField] bool isSpinning;
    [Range(-500f,500f)]
    [SerializeField] float spinSpeed;

    private Transform CurrentTarget;
    private void Awake()
    {
        CurrentTarget = Point_One;
    }
    void FixedUpdate()
    {
        if (isSpinning)
        {
            platformObject.transform.Rotate(0, 0, spinSpeed * Time.fixedDeltaTime);
        }
        if (isMoving)
        {
            float step = MovingSpeed * Time.deltaTime;

            if (platformObject.transform.position == Point_One.position)
            {
                CurrentTarget = Point_Two;
            }
            else if (platformObject.transform.position == Point_Two.position)
            {
                CurrentTarget = Point_One;
            }

            platformObject.transform.position = Vector2.MoveTowards(platformObject.transform.position, CurrentTarget.position, step);
        }
        return;
    }
}
