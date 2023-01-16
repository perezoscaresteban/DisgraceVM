using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Tilemaps.Tilemap;

public class ControlScript : MonoBehaviour
{

    /* PRIMERA IMPLEMENTACION DE MECANICA
    nombre_apellido_desafio2

    Se debera hacer un Script que contenga las variables: 
    * vida
    * velocidad
    * direccion

    Ademas, debera contener un metodo que:
    * controle el movimiento 
    * que cure al jugador (suba el valor de la vida)
    * que danie al jugador (baje el valor de la vida) 
    No es necesario que esten implementados (es decir, que hagan algo al darle play) pero si es necesario
    que se encuentren bien armados.
    Pueden valerse de los metodos Start y Update para probar si sus metodos funcionan
    */


    /*
            CONTROLS
            W forward
            S backward
            A left
            D right
            SpaceBar increase speed
     */

    [SerializeField] private string m_name;
    [SerializeField] private float life;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float turboSpeed;
    private float speed;

    public GameObject bullet;
    public Transform bulletStartPointC;
    public Transform bulletStartPointL;
    public Transform bulletStartPointR;


    private void Awake()
    {
        speed = normalSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        //    
    }

    // Update is called once per frame
    void Update()
    {
        //Acelerate();
        MoveDirection();
        Shot();

    }

    //Desafio de Debug.Log de una variable cuando cambia su valor
    private void HealLife(float n)
    {
        Debug.Log("Increase Life from " + life + " to " + life+n);
        life += n;
    }

    private void DamageLife(float n)
    {
        life -= n;
    }

    private void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    /*Este metodo no cambia realmente la posicion sino la variable "direccion".
     Ya que no cambia el Transform del objeto.
     Debajo implemente MoveDirection() para mover el objeto y este si usa dentro a 
     transform.Translate e Input.GetKey(KeyCode...
     Pero deje esto asi ya que el ejercicio decia:
     "Se debera hacer un Script que contenga las variables ... direccion" */
    private void ChangeDirection(float x,float y,float z)
    {
        direction = new Vector3(x, y, z);
    }


    /*De momento solo entendi como usar imputs de teclas, y no los axis vertical u horizontal,
     asi que mi cubo se desplaza con comandos ASWD.
     Tiene una velocidad base y una mas rapida, cuando se presiona la barra espaciadora va a 
     la mas rapida y cuando se suelta la misma vuelve a velocidad normal*/
    private void Acelerate()
    {

        if (Input.GetKey(KeyCode.Space)) 
        {
            ChangeSpeed(turboSpeed);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ChangeSpeed(normalSpeed);
        }
    }

    private void MoveDirection()
    {
        float moveSpeed = speed;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime);
        }
    }

    private void Shot()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(bullet, bulletStartPointL);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(bullet, bulletStartPointC);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(bullet, bulletStartPointR);
        }
    }
}
