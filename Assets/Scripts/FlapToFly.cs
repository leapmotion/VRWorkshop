using UnityEngine;
using System.Collections;
using Leap;

public class FlapToFly : MonoBehaviour {

  public Rigidbody target;

  private const float BUMP_FORCE = 200.0f;
  private bool resting_ = true;
  private const float VELOCITY_TRIGGER = 400.0f;

	void Update () {
	  Hand leap_hand = GetComponent<HandModel>().GetLeapHand();

    if (leap_hand != null) {
      bool trigger = leap_hand.PalmVelocity.Magnitude > VELOCITY_TRIGGER;
      if (resting_ && trigger)
        target.AddForce(Vector3.up * BUMP_FORCE);

      resting_ = !trigger;
    }  
	}
}
