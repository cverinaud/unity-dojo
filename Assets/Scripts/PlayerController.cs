using UnityEngine;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField] Rigidbody2D _rigidBody;
	[SerializeField] Vector2 _velocity = new Vector2(-4.0f, 1.0f);
	[SerializeField] Vector2 _jumpForce = new Vector2(0.0f, 200.0f);
	[SerializeField] BoxCollider2D _collider;

	Vector2 _currentVelocity;
	Vector2 _currentPosition;

	bool _jumping = false;

	public float _distanceToGround = 0.4f;

	bool IsGrounded()
	{
		_distanceToGround = _collider.bounds.size.y;
		RaycastHit2D hit = Physics2D.Raycast(_currentPosition, -Vector2.right, _distanceToGround + 0.1f);

		return hit != null;
 	}

	void FixedUpdate()
	{
		_currentVelocity = _rigidBody.velocity;
		_currentPosition = _rigidBody.position;

		if (IsGrounded())
		{
			_jumping = false;
		}

		Vector2 velocity;
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			velocity = _currentVelocity;
			velocity.x = _velocity.x;

			_rigidBody.velocity = velocity;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			velocity = _currentVelocity;
			velocity.x = -_velocity.x;

			_rigidBody.velocity = velocity;
		}
		else
		{
			velocity = _currentVelocity;
			velocity.x = 0.0f;

			_rigidBody.velocity = velocity;
		}

		if (Input.GetKeyDown(KeyCode.Space) && !_jumping)
		{
			_jumping = true;
 			_rigidBody.AddForce(Vector2.up * 400.0f);
		}
	}
}
