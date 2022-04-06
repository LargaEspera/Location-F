using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //отсылка на CharacterController

    public float speed = 10; // скорость движения 
    public float gravity = -30f; // скорость свободного падения(так как он нужен для падение он с минусом)
    public float jumpHeight = 3f;

    public Transform groundCheck; //emptyObject который определяет стоим ли мы на поверхности
    public float groundDistance = 0.4f; //дистанция при которой будет считаться что мы на поверхности
    public LayerMask groundMask; // маска для определение поверхности

    Vector3 velocity; //скорость падения на землю
    bool isGrounded; //bool стоим ли мы на поверхности 

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); // проверяем по позиции groundCheck попадает ли поверхность с нужной groundMask в диаметр groundDistance

        //Debug.Log(isGrounded);
        if (isGrounded && velocity.y < 0){ // короче пошел ты нахуй пидорас
            velocity.y = -2f;
        }        

        float x = Input.GetAxis("Horizontal"); // при нажатии клавиши (вперед, назад) возвращает (1, -1)
        float z = Input.GetAxis("Vertical");// при нажатии клавиши (влево, вправо) возвращает (1, -1)
        
        Vector3 move = transform.right * x + transform.forward * z; // берем у объекта скрипта правую сторону и умножаем на 1 либо на -1(если 1 - мы двигаесмся вправо, если -1 - мы двигаемся влево). с forward тоже самое
        controller.Move(move * speed * Time.deltaTime);// с помощью встроенного метода Move просто передвигаемся в ту сторону которую мы хотим(предварительно умножив на скорость и deltaTime)

        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime; // прибавляем к скорости падения педереную gravity умноженую на deltaTime
        controller.Move(velocity * Time.deltaTime); // так как падение со временем ускоряется мы опять умножаем на deltaTime
    }
}
