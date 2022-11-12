using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    private Rigidbody _myRigidbody;
    public Vector2 sensibility = new (1, 1);
    private new Transform camera;


    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;
        _myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (horizontal !=0 || vertical !=0)
        {
            transform.position += new Vector3(horizontal, 0, vertical) * _speed * Time.deltaTime;
        }

        float hor = Input.GetAxisRaw("Mouse X");
        float ver = Input.GetAxisRaw("Mouse Y");

        if (hor != 0)
        {
            transform.Rotate(Vector3.up * hor * sensibility.x);
        }

        if (ver != 0)
        {
            float angle = (camera.localEulerAngles.x - ver * sensibility.y + 360) % 360;
            if (angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -80, 80);
            camera.localEulerAngles = Vector3.right * angle;
            //camera.Rotate(Vector3.left * ver * sensibility.y);
        }
    }
}
