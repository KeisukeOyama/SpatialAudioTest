using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HearXR;
using UnityEngine.UI;

public class TestAppManager : MonoBehaviour
{
    
    [SerializeField] private GameObject headObj = null;
    [SerializeField] private Text angelX = null;
    [SerializeField] private Text angelY = null;
    [SerializeField] private Text angelZ = null;

    void Start()
    {
        
        HeadphoneMotion.Init();

        if (HeadphoneMotion.IsHeadphoneMotionAvailable())
        {
            // Subscribe to the rotation callback.
            // Alternatively, you can subscribe to OnHeadRotationRaw event to get the 
            // x, y, z, w values as they come from the API.
            HeadphoneMotion.OnHeadRotationQuaternion += HandleHeadRotationQuaternion;

            // Start tracking headphone motion.
            HeadphoneMotion.StartTracking();
        }
    }

    void Update()
    {


    }

    private void HandleHeadRotationQuaternion(Quaternion rotation)
    {
        headObj.transform.rotation = rotation;
        Vector3 eularAngle = rotation.eulerAngles;
        angelX.text = "x = " + eularAngle.x;
        angelY.text = "y = " + eularAngle.y;
        angelZ.text = "z = " + eularAngle.z;

    }
}
