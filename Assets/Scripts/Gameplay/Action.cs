using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Action : MonoBehaviour
{

    [SerializeField] RatSphere ratSphere;
    [SerializeField] Transform ratSpherePoint;
    [SerializeField] float timeToReload;
    [SerializeField] Transform point;
    [SerializeField] float range;
    private float timer;

    void Awake()
    {

    }
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time > timer)
            {
                Instantiate(ratSphere, ratSpherePoint.position, Quaternion.Euler(Vector3.forward));
                timer = Time.time + timeToReload;
            }
        }
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(point.transform.position, point.transform.forward * range);
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(ray, out hitInfo, range))
        {
            Debug.DrawRay(ray.origin, ray.direction * range, Color.red);
            if (hitInfo.collider.tag == "Coin")
            {
                var coin = hitInfo.collider.GetComponent<Coin>();
                coin.Take();
                Debug.Log(GameManager.Instance.coins);
            }
        }
    }
}
