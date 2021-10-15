using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeviceRotation
{
    private static bool gyroInitialized = false;

    public static bool HasGyroscope
    {
        get
        {
            return SystemInfo.supportsGyroscope;
        }
    }

    public static Quaternion Get()
    {
        if (!gyroInitialized)
        {
            InitGyro();
        }

        return HasGyroscope ? ReadGyroscopeRotation() : Quaternion.identity;
    }

    private static void InitGyro()
    {
        if (HasGyroscope)
        {
            Input.gyro.enabled = true;
            Input.gyro.updateInterval = 0.0167f;
        }

        gyroInitialized = true;
    }

    private static Quaternion ReadGyroscopeRotation()
    {
        Debug.Log("X: " + Input.gyro.attitude.x + "Z:" + Input.gyro.attitude.z);
        return new Quaternion(-Input.gyro.attitude.x, -Input.gyro.attitude.z * 10, -Input.gyro.attitude.y, 1);
        return new Quaternion(0.5f, 0.5f, 0.5f, 0.5f) * Input.gyro.attitude * new Quaternion(0, 0, 1, 0);
    }
}
