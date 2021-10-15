    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float upSpeed = 2f;
    [SerializeField] private float maxSpeed = 10f;

    private Rigidbody rb;

    [SerializeField] Vector3 forceVec;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
        Input.location.Start();
    }

    private void Update()
    {
        // GYROSCOPIO:
        //Quaternion deviceRotation = DeviceRotation.Get();

        //transform.rotation = deviceRotation;

        Quaternion gyro = Input.gyro.attitude;
        //gyro = Quaternion.Euler(gyro.eulerAngles + new Vector3(90, 0, 0));
        Vector3 rot = gyro.eulerAngles;
        float rotY = transform.rotation.y;
        transform.rotation = Quaternion.Euler(-gyro.x * 120, rotY - gyro.z * 120, -gyro.y * 120);//Quaternion.Lerp (transform.rotation, gyro, Time.time * 5);




        // ACELEROMETRO:
        //Vector3 acc = GetAccelerometerValue();
        //transform.position = acc;

        //Debug.Log("X: " + Input.acceleration.x + "Y: " + Input.acceleration.y + "Z:" + Input.acceleration.z);
        //rb.AddForce(Input.gyro.userAcceleration.x * forceVec);

        //Vector3 acceleration = Vector3.zero;
        //foreach (AccelerationEvent accEvent in Input.accelerationEvents)
        //{
        //    acceleration += accEvent.acceleration * accEvent.deltaTime;
        //}
        ////print(acceleration);
        ////transform.Translate(acceleration);
        //LocationInfo location = Input.location.lastData;
        //print(location.latitude + "," + location.longitude);
        //Debug.Log("X: " + acceleration.x + "Y: " + acceleration.y + "Z:" + acceleration.z);
        //print(Input.accelerationEvents);

        print(Input.acceleration);

        //Vector3 dir = Vector3.zero;
        //// we assume that the device is held parallel to the ground
        //// and the Home button is in the right hand

        //// remap the device acceleration axis to game coordinates:
        //// 1) XY plane of the device is mapped onto XZ plane
        //// 2) rotated 90 degrees around Y axis

        //dir.x = -Input.acceleration.y;
        //dir.z = Input.acceleration.x;

        //// clamp acceleration vector to the unit sphere
        //if (dir.sqrMagnitude > 1)
        //    dir.Normalize();

        //// Make it move 10 meters per second instead of 10 meters per frame...
        //dir *= Time.deltaTime;

        //// Move object
        //transform.Translate(dir * speed);
    }

    Vector3 GetAccelerometerValue()
    {
        Vector3 acc = Vector3.zero;
        float period = 0.0f;

        foreach (AccelerationEvent evnt in Input.accelerationEvents)
        {
            acc += evnt.acceleration * evnt.deltaTime;
            period += evnt.deltaTime;
        }
        if (period > 0)
        {
            acc *= 1.0f / period;
        }
        return acc;
    }
}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Gyro : MonoBehaviour
//{
//    private bool gyroEnabled;
//    private Gyroscope gyro;

//    private GameObject cameraContainer;
//    private Quaternion rot;

//    private void Start()
//    {
//        cameraContainer = new GameObject("Camera Container");
//        cameraContainer.transform.position = transform.position;
//        transform.SetParent(cameraContainer.transform);

//        gyroEnabled = EnableGyro();
//    }

//    private bool EnableGyro()
//    {
//        if (SystemInfo.supportsGyroscope)
//        {
//            gyro = Input.gyro;
//            gyro.enabled = true;

//            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
//            rot = new Quaternion(0, 0, 1, 0);

//            return true;
//        }
//        return false;
//    }
//    private void Update()
//    {
//        if (gyroEnabled)
//        {
//            transform.localRotation = gyro.attitude * rot;
//        }
//    }
//}


//public class AccelerationEvents : MonoBehaviour
//{
//    void Update()
//    {
//        GetAccelerometerValue();
//    }

//    Vector3 GetAccelerometerValue()
//    {
//        Vector3 acc = Vector3.zero;
//        float period = 0.0f;

//        foreach (AccelerationEvent evnt in Input.accelerationEvents)
//        {
//            acc += evnt.acceleration * evnt.deltaTime;
//            period += evnt.deltaTime;
//        }
//        if (period > 0)
//        {
//            acc *= 1.0f / period;
//        }
//        return acc;
//    }
//}



//Gyroscope gyro;
//public GameObject cube;
//public float speedMod;

//private void Start()
//{
//    Input.gyro.enabled = true;
//    gyro = Input.gyro;
//}

//private void Update()
//{
//    //transform.LookAt(cube.transform);
//    //print(Input.gyro.rotationRate);
//    //print(Input.touchCount);
//    //print("CAN SWIPE STICK: " + canSwipeStick);

//    if (Input.touchCount == 0)
//    {
//        if (gyro.rotationRate.y > 0.05)
//        {
//            transform.RotateAround(cube.transform.position, Vector3.up, -Time.deltaTime * speedMod);
//        }
//        if (gyro.rotationRate.y < -0.05)
//        {
//            transform.RotateAround(cube.transform.position, Vector3.up, Time.deltaTime * speedMod);
//        }
//    }
//    //else if (Input.touchCount == 2 && canSwipeStick)  //&& Input.GetTouch(1).phase == TouchPhase.Began
//    //{
//    //    bool moveObject = false;

//    //    switch (Input.GetTouch(1).phase)
//    //    {
//    //        case TouchPhase.Began:
//    //            startPos = Input.GetTouch(1).position;

//    //            ray = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
//    //            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
//    //            break;


//    //        case TouchPhase.Ended:
//    //            float swipeDist = Input.GetTouch(1).position.y - startPos.y;

//    //            print(swipeDist);

//    //            if (swipeDist < minSwipeDist)
//    //            {
//    //                moveObject = true;
//    //                print("ME MUEVOOOOOOO");
//    //            }
//    //            break;
//    //    }

//    //    if (Physics.Raycast(ray, out hit))
//    //    {
//    //        Debug.Log(hit.transform.name);
//    //        if (hit.collider != null && moveObject)
//    //        {
//    //            touchedObject = hit.transform.gameObject;
//    //            Debug.Log("Touched " + touchedObject.transform.name);

//    //            if (touchedObject.tag == "Stick" && canSwipeStick)
//    //            {
//    //                MoveAndDestroy(touchedObject);
//    //            }

//    //        }
//    //    }
//    //}
//}