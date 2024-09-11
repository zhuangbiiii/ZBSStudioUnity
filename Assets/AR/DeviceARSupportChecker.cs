using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class DeviceARSupportChecker : MonoBehaviour
{
    [SerializeField] ARSession arSession;

    [SerializeField] Text textLabel;


    // When the script starts, check if the device supports AR
    IEnumerator Start()
    {
        // AR session state @see https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.1/manual/features/session.html#session-state
        if ((ARSession.state == ARSessionState.None) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            ShowDebugLog("Checking AR availability...");
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            // Start some fallback experience for unsupported devices
            ShowDebugLog("AR is not supported on this device");
        }
        else
        {
            // Start the AR session
            arSession.enabled = true;
            ShowDebugLog("AR is supported on this device");
        }

        // Check if the device supports camera @see https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.1/manual/features/Camera/platform-support.html#check-for-camera-support
        if (LoaderUtility
            .GetActiveLoader()?
            .GetLoadedSubsystem<XRCameraSubsystem>() != null)
        {
            // XRCameraSubsystem was loaded. The platform supports the camera subsystem.
            ShowDebugLog("Camera subsystem is supported on this device");
        }
        else
        {
            // XRCameraSubsystem was not loaded. The platform does not support the camera subsystem.
            ShowDebugLog("Camera subsystem is not supported on this device");
        }

        // Check if the device supports plane detection @see https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.1/manual/features/plane-detection/platform-support.html#check-for-plane-detection-support
        if (LoaderUtility
            .GetActiveLoader()?
            .GetLoadedSubsystem<XRPlaneSubsystem>() != null)
        {
            // XRPlaneSubsystem was loaded. The platform supports plane detection.
            ShowDebugLog("Plane detection is supported on this device");
        }
        else
        {
            // XRPlaneSubsystem was not loaded. The platform does not support plane detection.
            ShowDebugLog("Plane detection is not supported on this device");
        }

        // subscribe to the AR Plane Manager changed event
        SubscribeToPlanesChanged();
    }

    // register the AR Plane Manager changed event @see https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.1/manual/features/plane-detection/arplanemanager.html#respond-to-detected-planes
    public void OnPlanesChanged(ARPlanesChangedEventArgs changes)
    {
        foreach (var plane in changes.added)
        {
            // handle added planes
            Debug.Log("123");
            //Debug.Log(plane.center);
        }

        foreach (var plane in changes.updated)
        {
            // handle updated planes
        }

        foreach (var plane in changes.removed)
        {
            // handle removed planes
        }
    }

    // subscribe to the AR Plane Manager changed event
    void SubscribeToPlanesChanged()
    {
        // This is inefficient. You should re-use a saved reference instead.
        var manager = Object.FindObjectOfType<ARPlaneManager>();

        if (manager != null)
        {
            manager.planesChanged += OnPlanesChanged;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Show a debug log on the label
    public void ShowDebugLog(string message)
    {
        textLabel.text += message;
        textLabel.text += "\n";
    }
}
