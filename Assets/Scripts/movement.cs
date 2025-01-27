using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

public class movement : MonoBehaviour
{

    public GameObject RightShoulderRoll;
    public GameObject RightShoulderPitch;
    public GameObject RightArm;
    public GameObject LeftShoulderPitch;
    public GameObject LeftShoulderRoll;
    public GameObject LeftArm;
    //public GameObject Torso;
    public GameObject RightHipYaw;
    public GameObject RightHipPitch;
    public GameObject RightHipRoll;
    public GameObject RightKnee;
    public GameObject RightAnkle;
    public GameObject RightFoot;
    public GameObject LeftHipRoll;
    public GameObject LeftHipPitch;
    public GameObject LeftHipYaw;
    public GameObject LeftKnee;
    public GameObject LeftAnkle;
    public GameObject LeftFoot;

    public int RightShoulderRollVal;
    public int RightShoulderPitchVal;
    public int RightArmVal;
    public int LeftShoulderPitchVal;
    public int LeftShoulderRollVal;
    public int LeftArmVal;
    //public int TorsoVal;
    public int RightHipYawVal;
    public int RightHipPitchVal;
    public int RightHipRollVal;
    public int RightKneeVal;
    public int RightAnkleVal;
    public int RightFootVal;
    public int LeftHipRollVal;
    public int LeftHipPitchVal;
    public int LeftHipYawVal;
    public int LeftKneeVal;
    public int LeftAnkleVal;
    public int LeftFootVal;


    private string serverUrl = "ws://localhost:3000";
    private string apiKey = "A1B2-C3D4-E5F6-G7H8-I9";
    private WebSocket ws = null;

    //Vectors to store rotational coord
    Vector3 RightShoulderRoll_coord = new Vector3(0,0,0);
    Vector3 RightShoulderPitch_coord = new Vector3(0,0,0);
    Vector3 RightArm_coord = new Vector3(0,0,0);

    Vector3 LeftShoulderPitch_coord = new Vector3(0,0,0);
    Vector3 LeftShoulderRoll_coord = new Vector3(0,0,0);
    Vector3 LeftArm_coord = new Vector3(0,0,0);
    //Vector3 Torso_coord = new Vector3(0,0,0);

    Vector3 RightHipYaw_coord = new Vector3(0,0,0);
    Vector3 RightHipPitch_coord = new Vector3(0,0,0);
    Vector3 RightHipRoll_coord = new Vector3(0,0,0);
    Vector3 RightKnee_coord = new Vector3(0,0,0);
    Vector3 RightAnkle_coord = new Vector3(0,0,0);
    Vector3 RightFoot_coord = new Vector3(0,0,0);

    Vector3 LeftHipRoll_coord = new Vector3(0,0,0);
    Vector3 LeftHipPitch_coord = new Vector3(0,0,0);
    Vector3 LeftHipYaw_coord = new Vector3(0,0,0);
    Vector3 LeftKnee_coord = new Vector3(0,0,0);
    Vector3 LeftAnkle_coord = new Vector3(0,0,0);
    Vector3 LeftFoot_coord = new Vector3(0,0,0);

    private float smoothVelocity;
    private float lerpVel = 0.1f;


    private void Update()
    {
        try
        {
            if (ws == null)
            {
                ws = new WebSocket($"{serverUrl}?apiKey={apiKey}");
                ws.Connect();
                Debug.Log("ws connected");
                ws.OnMessage += (sender, e) =>
                {
                    string jsonData = e.Data;
                    ParseJsonData(jsonData);
                };
                Debug.Log("Created new ws instance");
                return;
            }


        

            RightShoulderRoll_coord.y = Mathf.LerpAngle(RightShoulderRoll_coord.y, RightShoulderRollVal, lerpVel);
            RightShoulderPitch_coord.x = Mathf.LerpAngle(RightShoulderPitch_coord.x, RightShoulderPitchVal, lerpVel);
            RightArm_coord.y = RightArmVal;
            LeftShoulderRoll_coord.y = Mathf.LerpAngle(LeftShoulderRoll_coord.y, LeftShoulderRollVal, lerpVel);
            LeftShoulderPitch_coord.x = Mathf.LerpAngle(LeftShoulderPitch_coord.x, LeftShoulderPitchVal, lerpVel);
            LeftArm_coord.y = LeftArmVal;

            RightHipYaw_coord.z = Mathf.LerpAngle(RightHipYaw_coord.z ,RightHipYawVal, lerpVel);
            RightHipRoll_coord.y = Mathf.LerpAngle(RightHipRoll_coord.y, RightHipRollVal, lerpVel);
            RightHipPitch_coord.x = Mathf.LerpAngle(RightHipPitch_coord.x,RightHipPitchVal, lerpVel);
            RightKnee_coord.x = Mathf.LerpAngle(RightKnee_coord.x, RightKneeVal, lerpVel);
            RightAnkle_coord.x = Mathf.LerpAngle(RightAnkle_coord.x, RightAnkleVal, lerpVel);
            RightFoot_coord.y = Mathf.LerpAngle(RightFoot_coord.y, RightFootVal, lerpVel);

            LeftHipYaw_coord.z = Mathf.LerpAngle(LeftHipYaw_coord.z, LeftHipYawVal, lerpVel);
            LeftHipRoll_coord.y = Mathf.LerpAngle(LeftHipRoll_coord.y, LeftHipRollVal, lerpVel);
            LeftHipPitch_coord.x = Mathf.LerpAngle(LeftHipPitch_coord.x, LeftHipPitchVal, lerpVel);
            LeftKnee_coord.x = Mathf.LerpAngle(LeftKnee_coord.x, LeftKneeVal, lerpVel);
            LeftAnkle_coord.x = Mathf.LerpAngle(LeftAnkle_coord.x, LeftAnkleVal, lerpVel);
            LeftFoot_coord.y = Mathf.LerpAngle(LeftFoot_coord.y, LeftFootVal, lerpVel);

            //Assign local transformation
            RightShoulderRoll.transform.localEulerAngles = RightShoulderRoll_coord;
            RightShoulderPitch.transform.localEulerAngles = RightShoulderPitch_coord;
            RightArm.transform.localEulerAngles = RightArm_coord;
            LeftShoulderPitch.transform.localEulerAngles = LeftShoulderPitch_coord;
            LeftShoulderRoll.transform.localEulerAngles = LeftShoulderRoll_coord;
            LeftArm.transform.localEulerAngles = LeftArm_coord;

            RightHipYaw.transform.localEulerAngles = RightHipYaw_coord;
            Debug.Log("Right Hip Yaw: " + RightHipYawVal.ToString() + "|Coordy = " + RightHipYaw_coord.y);
            RightHipPitch.transform.localEulerAngles = RightHipPitch_coord;
            RightHipRoll.transform.localEulerAngles = RightHipRoll_coord;
            RightKnee.transform.localEulerAngles = RightKnee_coord;
            RightAnkle.transform.localEulerAngles = RightAnkle_coord;
            RightFoot.transform.localEulerAngles = RightFoot_coord;

            LeftHipRoll.transform.localEulerAngles = LeftHipRoll_coord;
            // Debug.Log("Right Hip Roll: " + LeftHipRollVal.ToString() + "|Coordy = " + LeftHipRoll_coord.y);
            LeftHipPitch.transform.localEulerAngles = LeftHipPitch_coord;
            LeftHipYaw.transform.localEulerAngles = LeftHipYaw_coord;
            LeftKnee.transform.localEulerAngles = LeftKnee_coord;
            LeftAnkle.transform.localEulerAngles = LeftAnkle_coord;
            LeftFoot.transform.localEulerAngles = LeftFoot_coord;

        }
        catch(Exception e)
        {
            Debug.LogError("Error mapping data: " + e.ToString());
        }




    }
    void ParseJsonData(string jsonData)
    {

        JointData bodyJoint = JsonConvert.DeserializeObject<JointData>(jsonData);

        RightShoulderRollVal = bodyJoint.RightShoulderRoll;
        RightShoulderPitchVal = bodyJoint.RightShoulderPitch;
        RightArmVal = bodyJoint.RightArm;
        LeftShoulderPitchVal = bodyJoint.LeftShoulderPitch;
        LeftShoulderRollVal = bodyJoint.LeftShoulderRoll;
        LeftArmVal = bodyJoint.LeftArm;
        // TorsoVal = bodyJoint.Torso;
        RightHipYawVal = bodyJoint.RightHipYaw;
        RightHipPitchVal = bodyJoint.RightHipPitch;
        RightHipRollVal = bodyJoint.RightHipRoll;
        RightKneeVal = bodyJoint.RightKnee;
        RightAnkleVal = bodyJoint.RightAnkle;
        RightFootVal = bodyJoint.RightFoot;
        LeftHipRollVal = bodyJoint.LeftHipRoll;
        LeftHipPitchVal = bodyJoint.LeftHipPitch;
        LeftHipYawVal = bodyJoint.LeftHipYaw;
        LeftKneeVal = bodyJoint.LeftKnee;
        LeftAnkleVal = bodyJoint.LeftAnkle;
        LeftFootVal = bodyJoint.LeftFoot;

        // Debug.Log("Right Hip Pitch: " + RightHipPitchVal.ToString());
    }
    private void OnApplicationQuit()
    {
        if (ws != null && ws.IsAlive)
        {
           ws.Close();
        }
    }

}

public class JointData
{
    public int RightShoulderRoll {get; set;}
    public int RightShoulderPitch {get; set;}
    public int RightArm {get; set;}
    public int LeftShoulderPitch {get; set;}
    public int LeftShoulderRoll {get; set;}
    public int LeftArm {get; set;}
    // public int Torso {get; set;}
    public int RightHipYaw {get; set;}
    public int RightHipPitch {get; set;}
    public int RightHipRoll {get; set;}
    public int RightKnee {get; set;}
    public int RightAnkle {get; set;}
    public int RightFoot {get; set;}
    public int LeftHipRoll {get; set;}
    public int LeftHipPitch {get; set;}
    public int LeftHipYaw {get; set;}
    public int LeftKnee {get; set;}
    public int LeftAnkle {get; set;}
    public int LeftFoot {get; set;}
}