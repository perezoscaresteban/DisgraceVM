using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Blink : Power
{
    void Awake()
    {
        var player = GameObject.Find("Player");
        player.transform.position = gameObject.transform.position + (new Vector3(0,1.2f,0));
        
    }

    void Update()
    {
        Destroy(gameObject, timerKill);
    }

        new public bool coorectTag(string tag)
    {
        return tag == "Ground";
    }

    public void Upgrade()
    {
        range *= 1.5f;
    }
}
