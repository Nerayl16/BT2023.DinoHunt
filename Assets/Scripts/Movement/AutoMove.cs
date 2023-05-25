using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Auto Move")]
[RequireComponent(typeof(Rigidbody2D))]
public class AutoMove : Physics2DObject
{
	// These are the forces that will push the object every frame
	// don't forget they can be negative too!
	public Vector2 direction = new Vector2(1f, 0f);

	//is the push relative or absolute to the world?
	public bool relativeToRotation = true;
	public bool stopMovement = false;

	private Vector3 startPos;

	void Awake()
	{
		startPos = transform.position;
	}

	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		if (stopMovement)
			return;
		if (rigidbody2D == null)
			rigidbody2D = GetComponent<Rigidbody2D>();
		if(relativeToRotation)
		{
			rigidbody2D.AddRelativeForce(direction * 2f);
		}
		else
		{
			//rigidbody2D.AddForce(direction * 2f);
			rigidbody2D.velocity = direction * 0.25f;
		}
	}

	public void FlipDirectionX()
	{
		direction = new Vector2(-direction.x, direction.y);
	}
	
	public void FlipDirectionY()
	{
		direction = new Vector2(direction.x, -direction.y);
	}
	
	public void ResetPosition()
	{
		transform.position = startPos;
	}

	public void StopMovement(bool val)
	{
		stopMovement = val;
		if (stopMovement)
			rigidbody2D.velocity = Vector2.zero;
	}	

	//Draw an arrow to show the direction in which the object will move
	void OnDrawGizmosSelected()
	{
		if(this.enabled)
		{
			float extraAngle = (relativeToRotation) ? transform.rotation.eulerAngles.z : 0f;
			Utils.DrawMoveArrowGizmo(transform.position, direction, extraAngle);
		}
	}
}
