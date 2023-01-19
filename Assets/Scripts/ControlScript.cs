using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Tilemaps.Tilemap;

public class ControlScript : MonoBehaviour
{


    /*IMPUTS
    Chatacter Move
    W -> Forward
    A -> Left
    S -> Backward
    D -> Right

    LeftControl -> Acelerate Movement (by inspector)

    Shots 
    J -> 1 Bullet 
    K -> 2 Bullets
    L -> 3 Bullets

    SpaceBar -> Duplicate the bullet size

    (AutoShoot by inspector)
    (Killbullet by inspector)
    */

    [SerializeField] private string m_name;
    [SerializeField] private float life;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float turboSpeed;
    private float speed;
    [SerializeField] private float timerAutoShot;
    private float timerAutoShot2;

    public GameObject bullet;
    public Transform bulletStartPointC;
    public Transform bulletStartPointL;
    public Transform bulletStartPointR;
    public Transform bulletStartPointAutoShot;



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
        Acelerate();
        MoveDirection();
        Shot();
        AutoShot();

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


    private void Acelerate()
    {

        if (Input.GetKey(KeyCode.LeftControl)) 
        {
            ChangeSpeed(turboSpeed);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
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

    /*Por alguna razon cuando instancia la Bullet la instancia con valores cambiados de "Scale"
    Y en lugar de esferas salen ovalos. Pero si cambo los valores "Scale" del prefab si salen esferas
    pero el prefab me queda un ovalo */
    private void Shot()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(bullet, bulletStartPointL);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(bullet, bulletStartPointC);
            Instantiate(bullet, bulletStartPointL);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(bullet, bulletStartPointC);
            Instantiate(bullet, bulletStartPointL);
            Instantiate(bullet, bulletStartPointR);
        }
    }

    private void AutoShot() 
    {
        if (timerAutoShot2 <= 0)
        {
            Instantiate(bullet, bulletStartPointAutoShot);
            timerAutoShot2 = timerAutoShot;
        }
        else 
        {
            timerAutoShot2 -= Time.deltaTime; 
        }
        
    }

}
