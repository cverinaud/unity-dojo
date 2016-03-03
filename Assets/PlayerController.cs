using UnityEngine;
using System.Collections;


namespace UnityDojo
{
	public class PlayerController : MonoBehaviour {
		public Camera camera;
		[SerializeField] Rigidbody2D _rigidbody2D;
		public float _velocityIntensity = 1.0f;
		public Vector2 _up = Vector2.up;
		public BoxCollider2D _collider;
		float _raycastSize;
		private int _layer;

		void Awake() {
			_raycastSize = _collider.bounds.extents.y;
			_layer = LayerMask.NameToLayer("Ground");
		}
		void UpdateCameraPosition(){
			Vector3 newCameraPosition = camera.transform.position;
			newCameraPosition.x = transform.position.x;
			camera.transform.position = newCameraPosition;
		}

		void FixedUpdate() {
			Vector2 velocity = _rigidbody2D.velocity;
			if (Input.GetKey(KeyCode.LeftArrow)) {
				velocity.x = -_velocityIntensity;
			} else if (Input.GetKey(KeyCode.RightArrow)) {
				velocity.x = _velocityIntensity;
			} else {
				velocity.x = 0;
			}
			_rigidbody2D.velocity = velocity;

			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				if (IsGrounded())
				{
					_rigidbody2D.AddForce(_up);
				}
			}
			UpdateCameraPosition();
		}

		bool IsGrounded() {
			RaycastHit2D hit = Physics2D.Raycast(
				_rigidbody2D.position,
				Vector2.down,
				_raycastSize + 0.1f, 1 << _layer);
			
			return hit.collider != null;
		}


	}
}