using UnityEngine;
using System.Collections;
using Leap;

public class MagicWand : MonoBehaviour {

  public GameObject wandSpawn;

  private const float VELOCITY_TRIGGER = 10000.0f;
  private const int SPAWN_WAIT_ITERATIONS = 20;
  private int wait = 0;

  void Update () {
    ToolModel tool_model = GetComponent<ToolModel>();
    Tool leap_tool = tool_model.GetLeapTool();

    if (leap_tool == null)
      return;

    if (leap_tool.TipVelocity.Magnitude > VELOCITY_TRIGGER && wandSpawn != null && wait <= 0) {
      Vector3 tip_position = tool_model.GetToolTipPosition();
      GameObject spawn = Instantiate(wandSpawn, tip_position, Quaternion.identity)
                         as GameObject;
      spawn.rigidbody.velocity = tool_model.GetToolTipVelocity();
      Physics.IgnoreCollision(collider, spawn.collider);
      wait = SPAWN_WAIT_ITERATIONS;
    }

    wait--;
  }
}
