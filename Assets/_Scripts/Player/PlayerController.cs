using DG.Tweening;
using UnityEditorInternal;
using UnityEngine;
using _Scripts.Objects;

namespace _Scripts.Player
{

	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private float _speed;
		[SerializeField] private float _runSpeedMultiplier;
		[SerializeField] private float _raycastRange;

		private Ray _raycastRay;
		private Transform _playerTransform;
		public bool Frozen { get; set; }

		void Start ()
		{
			_playerTransform = transform;
			_raycastRay = new Ray();
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Frozen) return;

			Vector3 inputs = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

			if (inputs.magnitude > 0)
			{
				_raycastRay.origin = _playerTransform.position;
				_raycastRay.direction = _playerTransform.position + inputs * _raycastRange;
			}

			inputs *= _speed;
			inputs *= Input.GetAxisRaw("Run") > 0 ? _runSpeedMultiplier : 1f;

			_playerTransform.DOMove(_playerTransform.position + inputs, 1f);

			if (!(Input.GetAxis("Interact") > 0)) return;
			RaycastHit raycastHit;

			if (!Physics.Raycast(_raycastRay, out raycastHit)) return;

			if (raycastHit.transform.CompareTag("InteractiveObject"))
				raycastHit.transform.GetComponent<InteractiveObject>().Interact();
		}

		void OnDrawGizmos()
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawRay(_raycastRay);
		}
	}
}
