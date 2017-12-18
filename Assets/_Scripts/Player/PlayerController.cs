using System;
using DG.Tweening;
using UnityEngine;
using _Scripts.Levels;
using _Scripts.Objects;

namespace _Scripts.Player
{

	public class PlayerController : MonoBehaviour
	{
		[SerializeField] public float Speed;
		[SerializeField] private float _runSpeedMultiplier;
		[SerializeField] private float _raycastRange;
		[SerializeField] private GameObject _snowBallPrefab;

		[SerializeField] private float _snowBallCooldown;
		private float _snowballTimer;

		public Animator PlayerAnimator { get; private set; }
		private Ray _raycastRay;
		private Transform _playerTransform;
		private Rigidbody _body;
		public bool Frozen { get; set; }

		void Start ()
		{
			_playerTransform = transform;
			_raycastRay = new Ray();
			PlayerAnimator = GetComponent<Animator>();
			_body = GetComponent<Rigidbody>();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
			if (Frozen) return;


			float h = Input.GetAxisRaw("Horizontal");
			float v = 0f;
			if (Math.Abs(h) < 0.0001f)
				v = Input.GetAxisRaw("Vertical");


			PlayerAnimator.SetInteger("Vertical", Mathf.RoundToInt(v));
			PlayerAnimator.SetInteger("Horizontal", Mathf.RoundToInt(h));

			Vector3 inputs = new Vector3(h, v);


			if (inputs.magnitude > 0)
			{
				_raycastRay.origin = _playerTransform.position;
				_raycastRay.direction = (_playerTransform.position + inputs) - _raycastRay.origin;
				
			}

			inputs *= Speed;
			inputs *= Input.GetAxisRaw("Run") > 0 ? _runSpeedMultiplier : 1f;
			inputs *= Time.fixedDeltaTime;

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
			_body.velocity = inputs;

			if (!(Input.GetAxis("Interact") > 0)) return;
			RaycastHit raycastHit;

			if (!Physics.Raycast(_raycastRay, out raycastHit, _raycastRange)) return;

			if (raycastHit.transform.CompareTag("InteractiveObject"))
			{
				InteractiveObject obj = raycastHit.transform.GetComponent<InteractiveObject>();
				if (obj != null)
					obj.Interact();

				LevelLoader lvl = raycastHit.transform.GetComponent<LevelLoader>();
				if (lvl != null)
					lvl.LoadLevel();

				EndAnimation endAn = raycastHit.transform.GetComponent<EndAnimation>();
				if (endAn != null)
					endAn.PlayEndAnimation();
			}
		}
	}
}
