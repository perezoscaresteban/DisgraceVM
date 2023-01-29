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

    */

    [SerializeField] private string m_name;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float turboSpeed;
    [SerializeField] private float rotationSpeed;
    private float speed;
    private Vector3 originalSize;

    public GameObject knife;
    public Transform shotOrigin1;
    public Transform shotOrigin2;
    public Transform shotOrigin3;

    void Start()
    {
        speed = normalSpeed;
        originalSize = new Vector3(transform.localScale.x,
                                   transform.localScale.y,
                                   transform.localScale.z);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Acelerate();
        RotateCharacter(GetRotationAmount());
        Move(GetMoveVector());
        Shot();

    }

    //Desafio de Debug.Log de una variable cuando cambia su valor
    private void ReciveHealth(float p_health)
    {
        var prevHealth = health;
        if (prevHealth + p_health <= maxHealth)
        {
            Debug.Log("Increase Health from " + prevHealth + " to " + prevHealth + p_health);
            health += p_health;
        }
        else
        {
            health = maxHealth;
        }

    }

    private void DamageLife(float p_health)
    {
        var prevHealth = health;
        if (prevHealth - p_health <= maxHealth)
        {
            Debug.Log("PJ DIED");
            health = 0;
        }
        else
        {
            health = -p_health;
            Debug.Log("Decrease Health from " + prevHealth + " to " + health);
        }
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

    public void ReSize(Vector3 newVector3) {
        transform.localScale = newVector3; 
    }

    public bool IsNormalSize() 
    {
        return transform.localScale == originalSize;
    }

    public Vector3 OriginalZise()
    {
        return originalSize;
    }
}
