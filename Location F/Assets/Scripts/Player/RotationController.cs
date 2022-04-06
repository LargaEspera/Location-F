using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float mouseSensitivity = 100; //параметр отвечающий за резкость мышки 
    
    public Transform playerBody; //тело игрока

    float xRotation = 0f; //переменная отвечающая за поворот камеры

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //отключение отображение мышки на экране 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // при движении мышки (влево вправо) определять угол наклона умноженный на чувствительность мыши и на интервал в секундах от последнего кадра до текущего
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // deltaTime нужно для избежания проблем с разной скорости поворота при разных кадрах в секунду

        xRotation -= mouseY; // инверсируем поворот по Y
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // задаем наксимальный и минимальный поворот верх и вниз для камеры
        
        transform.localRotation = Quaternion.Euler(xRotation, 0,0); //крутим камеру под найденый угол(только верх и вниз)
        playerBody.Rotate(Vector3.up * mouseX); // поварачиваем тело игрока влево и вправо
    }
}
