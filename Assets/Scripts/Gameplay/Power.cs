using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

public abstract class Power : MonoBehaviour
{
    public float damage;
    public float cooldown;
    public float timerKill;
    public float range;

    protected float timer;

    void Update()
    {

    }

    public bool coorectTag(string tag) 
    {
        return true;
    }
}
