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

    public GameObject knife;
    public Transform shotOrigin1;
    public Transform shotOrigin2;
    public Transform shotOrigin3;

    public GameObject temporizador;


    //
    public float sensX;
    public Transform orientation;
    public float yRotation;
    //

    private void Awake()
    {
        speed = normalSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(temporizador);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Acelerate();
        MoveVision();
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
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0) * moveSpeed * Time.deltaTime);
        }
    }

    /*Por alguna razon cuando instancia la Bullet la instancia con valores cambiados de "Scale"
    Y en lugar de esferas salen ovalos. Pero si cambo los valores "Scale" del prefab si salen esferas
    pero el prefab me queda un ovalo */
    private void Shot()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(knife, shotOrigin1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(knife, shotOrigin2);
            Instantiate(knife, shotOrigin3);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(knife, shotOrigin1);
            Instantiate(knife, shotOrigin2);
            Instantiate(knife, shotOrigin3);
        }
    }

    private void AutoShot() 
    {
        if (timerAutoShot2 <= 0)
        {
            Instantiate(knife, shotOrigin1);
            timerAutoShot2 = timerAutoShot;
        }
        else 
        {
            timerAutoShot2 -= Time.deltaTime; 
        }
        
    }

    void MoveVision()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;

        yRotation += mouseX;

        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

}
