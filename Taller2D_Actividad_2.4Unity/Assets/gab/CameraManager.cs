using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;

    [SerializeField] private CinemachineVirtualCamera vcam1;
    [SerializeField] private CinemachineVirtualCamera vcam2;


    void Awake()
    {
        instance = this;
    }


    public static CameraManager GetInstance()
    {
        return instance;
    }

    public void SwitchToCamera1()
    {
        vcam1.Priority = 10;
        vcam2.Priority = 0;
    }
    public void SwitchToCamera2()
    {
        vcam1.Priority = 0;
        vcam2.Priority = 10;
    }
}
