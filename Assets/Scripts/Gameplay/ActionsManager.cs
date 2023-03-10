using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.UI.Image;

public class ActionsManager : MonoBehaviour
{
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private Animator handsAnimator;
    [SerializeField] private KeyCode actionKey;
    [SerializeField] private KeyCode powerKey;
    [SerializeField] private KeyCode nextPower;
    [SerializeField] private List<Power> powersLs;
    [SerializeField] Transform origin;
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] Collider weaponCollider;
    private Dictionary<int, Power> powers;
    private int index;
    private int maxIndex;
    private float timer;
    private Power power;
    private float holdTimer;

    void Awake() 
    { 
        index = 0;
        powers = new Dictionary<int, Power>();
        foreach (Power e in powersLs) 
        {
            powers.Add(index, e);
            index++;
        }
        index = 0;
        maxIndex = powersLs.Count-1;
        power = powers[0];
    }

    void Update() 
    {

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) 
        { 
            HUD.Instance.Pause();
        }
        if (Time.time > holdTimer)
        {
            handsAnimator.SetBool("Power", false);
            handsAnimator.SetBool("Attack", false);
        }

        if (Input.GetKeyDown(attackKey))
        {
            handsAnimator.SetBool("Attack", true);
            /*
            Ray ray = new Ray(origin.transform.position, origin.transform.forward * 2);
            RaycastHit hitInfo;
            weaponCollider.enabled = true;
            Debug.DrawRay(ray.origin, ray.direction, Color.yellow);

            if (Physics.Raycast(ray, out hitInfo, 2))
            {
                if (hitInfo.collider.tag == "Enemy")
                {
                    var enemy = hitInfo.collider.GetComponent<EnemyHealthController>();
                    enemy.TakeDamage(5);
                }
            }*/
            holdTimer = Time.time + 1;
            //handsAnimator.SetBool("Attack", false);

        }

        if (Input.GetKeyDown(nextPower)) 
        {
            NextPower();
        }
        if (Input.GetKeyDown(actionKey))
        {
            Ray ray = new Ray(origin.transform.position, origin.transform.forward * 2);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 2))
            {
                if (hitInfo.collider.tag == "Coin")
                {
                    var coin = hitInfo.collider.GetComponent<Coin>();
                    coin.Take();
                }
            }
        }
        if (Input.GetKeyDown(powerKey) && Time.time > timer)
        {
            Ray ray = new Ray(origin.transform.position, origin.transform.forward * power.range);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, power.range)) 
            {
                Debug.DrawRay(ray.origin, hitInfo.point, Color.yellow);
                if (power.coorectTag(hitInfo.collider.tag)) 
                {
                    handsAnimator.SetBool("Power", true);
                    Instantiate(power, origin.position +  ray.direction* hitInfo.distance, Quaternion.Euler(Vector3.forward));
                    timer = Time.time + power.cooldown;
                    holdTimer = Time.time + 1;
                }
            }
        }
    }

    public void NextPower()
    {
        if (index + 1 > maxIndex) 
        {
            index = 0;
        }
        else
        {
            index++;
        }
        power = powers[index];
    }
}
