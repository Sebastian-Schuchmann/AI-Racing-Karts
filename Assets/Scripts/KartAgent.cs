using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class KartAgent : Agent
{
   public CheckpointManager _checkpointManager;
   private KartController _kartController;
   
   public override void Initialize()
   {
      _kartController = GetComponent<KartController>();
   }
   
   public override void OnEpisodeBegin()
   {
      _checkpointManager.ResetCheckpoints();
      _kartController.Respawn();
   }

   public override void CollectObservations(VectorSensor sensor)
   {
      Vector3 diff = _checkpointManager.nextCheckPointToReach.transform.position - transform.position;
      sensor.AddObservation(diff / 20f);
      AddReward(-0.001f);
   }

   public override void OnActionReceived(ActionBuffers actions)
   {
      var Actions = actions.ContinuousActions;
      
      _kartController.ApplyAcceleration(Actions[1]);
      _kartController.Steer(Actions[0]);
      _kartController.AnimateKart(Actions[0]);
   }
   
   public override void Heuristic(in ActionBuffers actionsOut)
   {
      var continousActions = actionsOut.ContinuousActions;
      continousActions.Clear();
      
      continousActions[0] = Input.GetAxis("Horizontal");
      continousActions[1] = Input.GetKey(KeyCode.W) ? 1f : 0f;
   }
}
