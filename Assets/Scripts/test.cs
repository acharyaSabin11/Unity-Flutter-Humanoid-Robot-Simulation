// //using System.Globalization;
// using System;
// using UnityEngine;

// public class ReceiveFromFlutterRotation : MonoBehaviour
// {
//     public GameObject RightShoulderRoll;
//     public GameObject RightShoulderPitch;
//     public GameObject RightArm;
//     public GameObject LeftShoulderPitch;
//     public GameObject LeftShoulderRoll;
//     public GameObject LeftArm;
//     public GameObject Torso;
//     public GameObject RightHipYaw;
//     public GameObject RightHipPitch;
//     public GameObject RightHipRoll;
//     public GameObject RightKnee;
//     public GameObject RightAnkle;
//     public GameObject RightFoot;
//     public GameObject LeftHipRoll;
//     public GameObject LeftHipPitch;
//     public GameObject LeftHipYaw;
//     public GameObject LeftKnee;
//     public GameObject LeftAnkle;
//     public GameObject LeftFoot;
    
//     // Called from Flutter:
//     public void SetRotationAngle(string data)
//     {
//         //SendToFlutter.Send("Hey flutter");
//         try
//         {
//             //SendToFlutter.Send($"Sent Data is: {data}");
//             AngleData angleData = JsonUtility.FromJson<AngleData>(data);
//             RightShoulderPitch.localRotation = Quaternion.Euler(new Vector3(90, 90, 90));
           
//             //SendToFlutter.Send("JSON Parsing Successful. The Rotation for RightShoulderPitch is {angleData.RightShoulderPitch}");
//         }
//         catch (Exception)
//         {
//             SendToFlutter.Send("Some Error Occured During the JSON Conversion");

//         }

// }
// }

// //[System.Serializable]
// //public class AngleData
// //{
    
// //    public string type;
// //    public float RightShoulderRoll;
// //    public float RightShoulderPitch;
// //    public float RightArm;
// //    public float LeftShoulderPitch;
// //    public float LeftShoulderRoll;
// //    public float LeftArm;
// //    public float Torso;
// //    public float RightHipYaw;
// //    public float RightHipPitch;
// //    public float RightHipRoll;
// //    public float RightKnee;
// //    public float RightAnkle;
// //    public float RightFoot;
// //    public float LeftHipRoll;
// //    public float LeftHipPitch;
// //    public float LeftHipYaw;
// //    public float LeftKnee;
// //    public float LeftAnkle;
// //    public float LeftFoot;
// //}