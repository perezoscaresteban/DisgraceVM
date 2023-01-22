using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera camera1;
    [SerializeField] private Camera camera2;
    [SerializeField] private Camera camera3;

    private List<Camera> cameras = new List<Camera>();

    void Start()
    {
        cameras.Add(camera1);
        cameras.Add(camera2);
        cameras.Add(camera3);
        cameras[0].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameras[0].gameObject.SetActive(false);
            cameras.Add(cameras[0]);
            cameras.RemoveAt(0);
            cameras[0].gameObject.SetActive(true);
        }
    }
}
