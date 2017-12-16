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

		private Transform _playerTransform;
		public bool Frozen { get; set; }

		void Start ()
		{
			_playerTransform = transform;
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Frozen) return;

			Vector3 inputs = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

			inputs *= _speed;
			inputs *= Input.GetAxisRaw("Run") > 0 ? _runSpeedMultiplier : 1f;

			_playerTransform.DOMove(_playerTransform.position + inputs, 1f);

			if (Input.GetAxis("Interact") > 0)
			{

			}
		}

		void OnDrawGizmos()
		{
		}
	}
}
