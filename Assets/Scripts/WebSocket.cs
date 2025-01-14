using WebSocketSharp;
using UnityEngine;
using System;
using System.Collections.Concurrent;

public class WebSocketClient : MonoBehaviour
{
    private WebSocket ws;
    private ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();

    // Define all transforms for humanoid joints
    public Transform RightShoulderRoll;
    public Transform RightShoulderPitch;
    public Transform RightArm;
    public Transform LeftShoulderPitch;
    public Transform LeftShoulderRoll;
    public Transform LeftArm;
    public Transform Torso;
    public Transform RightHipYaw;
    public Transform RightHipPitch;
    public Transform RightHipRoll;
    public Transform RightKnee;
    public Transform RightAnkle;
    public Transform RightFoot;
    public Transform LeftHipRoll;
    public Transform LeftHipPitch;
    public Transform LeftHipYaw;
    public Transform LeftKnee;
    public Transform LeftAnkle;
    public Transform LeftFoot;

    void Start()
    {
        // Initialize WebSocket connection
        ws = new WebSocket("ws://localhost:3000?apiKey=A1B2-C3D4-E5F6-G7H8-I9");

        ws.OnMessage += (sender, e) =>
        {
            // Enqueue the message to be processed on the main thread
            messageQueue.Enqueue(e.Data);
        };

        ws.OnError += (sender, e) =>
        {
            Debug.LogError($"WebSocket Error: {e.Message}");
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log($"WebSocket Closed: Code={e.Code}, Reason={e.Reason}");
        };

        ws.Connect();
    }

    void Update()
    {
        // Process all messages received from the WebSocket
        while (messageQueue.TryDequeue(out string message))
        {
            try
            {
                // Parse JSON data and update transforms
                AngleData angleData = JsonUtility.FromJson<AngleData>(message);
                UpdateJointRotations(angleData);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error parsing message or updating transforms: {ex.Message}");
            }
        }
    }

    private void UpdateJointRotations(AngleData angleData)
    {
        // Right side
        //if (RightShoulderPitch != null && RightShoulderPitch.gameObject.activeInHierarchy)
        //{
        //    RightShoulderPitch.localRotation = Quaternion.Euler(new Vector3(-angleData.RightShoulderPitch + 90, 0, 0));
        //}
        //if (RightShoulderRoll != null && RightShoulderRoll.gameObject.activeInHierarchy)
        //{
        //    RightShoulderRoll.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.RightShoulderRoll - 160));
        //}
        //if (RightArm != null && RightArm.gameObject.activeInHierarchy)
        //{
        //    RightArm.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.RightArm));
        //}
        if (RightHipYaw != null && RightHipYaw.gameObject.activeInHierarchy)
        {
            RightHipYaw.localRotation = Quaternion.Euler(new Vector3(0, angleData.RightHipYaw, 0));
        }
        if (RightHipPitch != null && RightHipPitch.gameObject.activeInHierarchy)
        {
            RightHipPitch.localRotation =Quaternion.Euler(new Vector3(angleData.RightHipPitch, RightHipPitch.localRotation.eulerAngles.y, RightHipPitch.localRotation.eulerAngles.z)) * RightHipPitch.parent.rotation;
        }
        //if (RightHipRoll != null && RightHipRoll.gameObject.activeInHierarchy)
        //{
        //    RightHipRoll.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.RightHipRoll));
        //}
        //if (RightKnee != null && RightKnee.gameObject.activeInHierarchy)
        //{
        //    RightKnee.localRotation = Quaternion.Euler(new Vector3(angleData.RightKnee, 0, 0));
        //}
        //if (RightAnkle != null && RightAnkle.gameObject.activeInHierarchy)
        //{
        //    RightAnkle.localRotation = Quaternion.Euler(new Vector3(angleData.RightAnkle, 0, 0));
        //}
        //if (RightFoot != null && RightFoot.gameObject.activeInHierarchy)
        //{
        //    RightFoot.localRotation = Quaternion.Euler(new Vector3(0, angleData.RightFoot, 0));
        //}

        //// Left side
        //if (LeftShoulderPitch != null && LeftShoulderPitch.gameObject.activeInHierarchy)
        //{
        //    LeftShoulderPitch.localRotation = Quaternion.Euler(new Vector3(angleData.LeftShoulderPitch - 90, 0, 0));
        //}
        //if (LeftShoulderRoll != null && LeftShoulderRoll.gameObject.activeInHierarchy)
        //{
        //    LeftShoulderRoll.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.LeftShoulderRoll - 90));
        //}
        //if (LeftArm != null && LeftArm.gameObject.activeInHierarchy)
        //{
        //    LeftArm.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.LeftArm - 180));
        //}
        //if (LeftHipYaw != null && LeftHipYaw.gameObject.activeInHierarchy)
        //{
        //    LeftHipYaw.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.LeftHipYaw));
        //}
        //if (LeftHipPitch != null && LeftHipPitch.gameObject.activeInHierarchy)
        //{
        //    LeftHipPitch.localRotation = Quaternion.Euler(new Vector3(angleData.LeftHipPitch, 0, 0));
        //}
        //if (LeftHipRoll != null && LeftHipRoll.gameObject.activeInHierarchy)
        //{
        //    LeftHipRoll.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.LeftHipRoll));
        //}
        //if (LeftKnee != null && LeftKnee.gameObject.activeInHierarchy)
        //{
        //    LeftKnee.localRotation = Quaternion.Euler(new Vector3(angleData.LeftKnee, 0, 0));
        //}
        //if (LeftAnkle != null && LeftAnkle.gameObject.activeInHierarchy)
        //{
        //    LeftAnkle.localRotation = Quaternion.Euler(new Vector3(angleData.LeftAnkle, 0, 0));
        //}
        //if (LeftFoot != null && LeftFoot.gameObject.activeInHierarchy)
        //{
        //    LeftFoot.localRotation = Quaternion.Euler(new Vector3(0, angleData.LeftFoot, 0));
        //}

        //// Torso
        //if (Torso != null && Torso.gameObject.activeInHierarchy)
        //{
        //    Torso.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.Torso));
        //}
    }


    void OnDestroy()
    {
        if (ws != null)
        {
            ws.Close();
        }
    }
}

[System.Serializable]
public class AngleData
{
    public string type;
    public float RightShoulderRoll;
    public float RightShoulderPitch;
    public float RightArm;
    public float LeftShoulderPitch;
    public float LeftShoulderRoll;
    public float LeftArm;
    public float Torso;
    public float RightHipYaw;
    public float RightHipPitch;
    public float RightHipRoll;
    public float RightKnee;
    public float RightAnkle;
    public float RightFoot;
    public float LeftHipRoll;
    public float LeftHipPitch;
    public float LeftHipYaw;
    public float LeftKnee;
    public float LeftAnkle;
    public float LeftFoot;
}
