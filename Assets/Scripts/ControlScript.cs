using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Tilemaps.Tilemap;

public class ControlScript : MonoBehaviour
{


    /*INPUTS
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
    [SerializeField] private float normalSpeed;
    [SerializeField] private float turboSpeed;
    [SerializeField] private float rotationSpeed;
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
        RotateCharacter(GetRotationAmount());
        Move(GetMoveVector());
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

    private void Move(Vector3 moveDir)
    {
        transform.position += (moveDir.x * transform.right + moveDir.z * transform.forward) * (speed * Time.deltaTime);
    }

    private void RotateCharacter(float rotateAmount)
    {
        transform.Rotate(Vector3.up, rotateAmount * Time.deltaTime * rotationSpeed, Space.Self);
    }

    private float GetRotationAmount() 
    {
        return Input.GetAxis("Mouse X");
    }

    private Vector3 GetMoveVector()
    {
        var l_horizontal = Input.GetAxis("Horizontal");
        var l_vertical = Input.GetAxis("Vertical");

        return new Vector3(l_horizontal, 0, l_vertical).normalized;
    }

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

}
