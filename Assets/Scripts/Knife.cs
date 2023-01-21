using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Knife : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float damage;
    [SerializeField] private float timerKillKnife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += direction * speed;
        Rezise();
        Destroy(gameObject, timerKillKnife);
    }



    void Rezise()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = new Vector3(transform.localScale.x * 2,
                                               transform.localScale.y * 2,
                                               transform.localScale.z * 2);
        }
    }
}
