using System;
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
		[SerializeField] private GameObject _snowBallPrefab;

		[SerializeField] private float _snowBallCooldown;
		private float _snowballTimer;

		private Animator _playerAnimator;
		private Ray _raycastRay;
		private Transform _playerTransform;
		public bool Frozen { get; set; }

		void Start ()
		{
			_playerTransform = transform;
			_raycastRay = new Ray();
			_playerAnimator = GetComponent<Animator>();
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (Frozen) return;



			float h = Input.GetAxisRaw("Horizontal");
			float v = 0f;
			if (Math.Abs(h) < 0.0001f)
				v = Input.GetAxisRaw("Vertical");


			_playerAnimator.SetInteger("Vertical", Mathf.RoundToInt(v));
			_playerAnimator.SetInteger("Horizontal", Mathf.RoundToInt(h));

			Vector3 inputs = new Vector3(h, v);


			if (inputs.magnitude > 0)
			{
				_raycastRay.origin = _playerTransform.position;
				_raycastRay.direction = (_playerTransform.position + inputs) - _raycastRay.origin;
				_raycastRay.direction *= _raycastRange;
			}

			inputs *= _speed;
			inputs *= Input.GetAxisRaw("Run") > 0 ? _runSpeedMultiplier : 1f;
			inputs *= Time.deltaTime;

			if (Input.GetAxisRaw("Fire") > 0 && _snowballTimer >= _snowBallCooldown)
			{
				Vector3 dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				dest.z = -5;
				GameObject instance = Instantiate(_snowBallPrefab, transform.position + inputs, Quaternion.identity);
				instance.transform.DOMove(dest, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
				{
					Destroy(instance);
				});
				_snowballTimer = 0;
			}
			_snowballTimer += Time.deltaTime;
			_playerTransform.position += inputs;

			if (!(Input.GetAxis("Interact") > 0)) return;
			RaycastHit raycastHit;

			if (!Physics.Raycast(_raycastRay, out raycastHit)) return;

			if (raycastHit.transform.CompareTag("InteractiveObject"))
				raycastHit.transform.GetComponent<InteractiveObject>().Interact();
		}
	}
}
