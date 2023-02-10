using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] bool ableToAttack = true;
    [SerializeField] private Animator handsAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        if (Input.GetMouseButton(0) && ableToAttack)
        {
            Debug.Log("Presiono boton");
            ExecuteMeleeAttack();
        }
    }

    private void ExecuteMeleeAttack()
    {
        handsAnimator.SetBool("Attack", true);
    }
}
