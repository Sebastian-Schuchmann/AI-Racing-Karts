using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CameraCheckpoint
{
    public Camera camera;
    public Checkpoint checkpoint;
}

public class AutomaticCameraSystem : MonoBehaviour
{
    public CheckpointManager kartToFollow;
    public CameraCheckpoint[] cameraCheckpoints;

    private void Start()
    {
        setCameraActive(0);
        kartToFollow.reachedCheckpoint += OnReachedCheckpoint;
    }

    private void OnReachedCheckpoint(Checkpoint checkpoint)
    {
        foreach (CameraCheckpoint cameraCheckpoint in cameraCheckpoints)
        {
            if (cameraCheckpoint.checkpoint == checkpoint)
            {
                DeactivateAllCamera();
                cameraCheckpoint.camera.gameObject.SetActive(true);
            }
        }
    }


    public void setCameraActive(int index)
    {
        DeactivateAllCamera();

        cameraCheckpoints[index].camera.gameObject.SetActive(true);
    }

    private void DeactivateAllCamera()
    {
        foreach (CameraCheckpoint cameraCheckpoint in cameraCheckpoints)
        {
            cameraCheckpoint.camera.gameObject.SetActive(false);
        }
    }
}
