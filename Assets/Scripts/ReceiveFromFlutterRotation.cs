//using System.Globalization;
using System;
using UnityEngine;

public class ReceiveFromFlutterRotation : MonoBehaviour
{
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
    
    // Called from Flutter:
    public void SetRotationAngle(string data)
    {
        //SendToFlutter.Send("Hey flutter");
        try
        {
            //SendToFlutter.Send($"Sent Data is: {data}");
            AngleData angleData = JsonUtility.FromJson<AngleData>(data);
            //Vector3 targetRotationInDegrees = new Vector3(rotationAngle, 0, 0);
            //transform.rotation = Quaternion.Euler(targetRotationInDegrees);   
            //Rotating based on received values
            RightShoulderPitch.localRotation = Quaternion.Euler(new Vector3(-angleData.RightShoulderPitch+90, 0, 0));
            RightShoulderRoll.localRotation = Quaternion.Euler(new Vector3(0,0,angleData.RightShoulderRoll-160)); 
            RightArm.localRotation = Quaternion.Euler(new Vector3(0,0,angleData.RightArm)); 
            LeftShoulderPitch.localRotation = Quaternion.Euler(new Vector3(angleData.LeftShoulderPitch - 90, 0, 0));
            LeftShoulderRoll.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.LeftShoulderRoll-90));
            LeftArm.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.LeftArm - 180));
            //Torso.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.Torso));
            //RightHipYaw.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.RightHipYaw));
            //RightHipPitch.localRotation = Quaternion.Euler(new Vector3(angleData.RightHipPitch,0,0));
            //RightHipRoll.localRotation = Quaternion.Euler(new Vector3(0,angleData.RightHipRoll,0));
            //RightKnee.localRotation = Quaternion.Euler(new Vector3(angleData.RightKnee, 0, 0));
            //RightAnkle.localRotation = Quaternion.Euler(new Vector3(angleData.RightAnkle, 0, 0));
            //RightFoot.localRotation = Quaternion.Euler(new Vector3(0, angleData.RightFoot, 0));
            //LeftHipRoll.localRotation = Quaternion.Euler(new Vector3(0,angleData.LeftHipRoll, 0));
            //LeftHipPitch.localRotation = Quaternion.Euler(new Vector3(angleData.LeftHipPitch, 0,0));
            //LeftHipYaw.localRotation = Quaternion.Euler(new Vector3(0, 0, angleData.LeftHipYaw));
            //LeftKnee.localRotation = Quaternion.Euler(new Vector3(angleData.LeftKnee, 0, 0));
            //LeftAnkle.localRotation = Quaternion.Euler(new Vector3(angleData.LeftAnkle, 0, 0));
            //LeftFoot.localRotation = Quaternion.Euler(new Vector3(0,angleData.LeftFoot, 0));
            //SendToFlutter.Send("JSON Parsing Successful. The Rotation for RightShoulderPitch is {angleData.RightShoulderPitch}");
        }
        catch (Exception)
        {
            SendToFlutter.Send("Some Error Occured During the JSON Conversion");

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