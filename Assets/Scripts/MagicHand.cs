using UnityEngine;
using System.Collections;
using Leap;

public class MagicHand : MonoBehaviour {

  public GameObject handSpawn;

  private float GRAB_TRIGGER = 0.5f;
  private const float VELOCITY_SPAWN = 20.0f;
  private const int SPAWN_WAIT_ITERATIONS = 20;
  private int wait = 0;

  void Update () {
    SkeletalHand skeletal_hand = GetComponent<SkeletalHand>();
    Hand leap_hand = skeletal_hand.GetLeapHand();

    if (leap_hand == null)
      return;

    if (leap_hand.GrabStrength < GRAB_TRIGGER && handSpawn != null && wait <= 0) {
      GameObject spawn = Instantiate(handSpawn, skeletal_hand.GetPalmCenter(), Quaternion.identity)
                         as GameObject;
      spawn.rigidbody.velocity = VELOCITY_SPAWN * (skeletal_hand.GetPalmRotation() * Vector3.down);
      wait = SPAWN_WAIT_ITERATIONS;
      Physics.IgnoreCollision(skeletal_hand.palm.collider, spawn.collider);
    }

    wait--;
  }
}
