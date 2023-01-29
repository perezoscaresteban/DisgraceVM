using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UI;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
    public GameObject temporizador;
    private Temporizador temporizadorI;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        var l_controlScript = other.GetComponent<ControlScript>();
        if (l_controlScript != null && temporizadorI == null)
        {
            temporizadorI = Instantiate(temporizador).GetComponent<Temporizador>();
            if (l_controlScript.IsNormalSize())
            {
                l_controlScript.ReSize(new Vector3(
                    l_controlScript.transform.localScale.x / 2,
                    l_controlScript.transform.localScale.y / 2,
                    l_controlScript.transform.localScale.z / 2));
            }
            else
            {
                l_controlScript.ReSize(l_controlScript.OriginalZise());
            }
            LogTest(other);

        }
        else
        {
            if (temporizadorI.timeAccount() >= 1)
            {
                if (l_controlScript.IsNormalSize())
                {
                    l_controlScript.ReSize(new Vector3(
                        l_controlScript.transform.localScale.x / 2,
                        l_controlScript.transform.localScale.y / 2,
                        l_controlScript.transform.localScale.z / 2));
                }
                else
                {
                    l_controlScript.ReSize(l_controlScript.OriginalZise());
                }
                LogTest(other);

            }
        }

    }


    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (temporizadorI && temporizadorI.timeAccount() >= 1)
        {
            Destroy(temporizadorI);
            temporizadorI = null;
        }
    }

    private void LogTest(Component component)
    {
        Debug.Log(component.name + " collision with " + "InvisibleWall");
        if (component.TryGetComponent<ControlScript>(out var controlSrcipt))
        {
            Debug.Log("Tiene componente ControlScript");
        }
        else
        {
            Debug.Log("No tiene componente ControlScript");
        }
    }

}