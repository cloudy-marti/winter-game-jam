using DG.Tweening;
using UnityEngine;

namespace _Scripts.Player
{

	public class PlayerController : MonoBehaviour
	{
		private GameObject _objectInRange = null;


		[SerializeField] private float _speed;
		[SerializeField] private float _runSpeedMultiplier;
		[SerializeField] private Transform _rangeTransform;
		private Transform _playerTransform;

		void Start ()
		{
			_playerTransform = transform;
		}
	
		// Update is called once per frame
		void Update () {
			Vector3 inputs = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

			inputs *= _speed;
			_rangeTransform.position = _playerTransform.position + inputs * 1.5f;

			inputs *= (Input.GetAxisRaw("Run") > 0 ? _runSpeedMultiplier : 1f);
			_playerTransform.DOMove(inputs + _playerTransform.position, 1f);

			if (Input.GetAxis("Interact") > 0)
			{
				// interact
			}
		}
	}
}
