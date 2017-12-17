using JetBrains.Annotations;
using UnityEngine;

namespace _Scripts.Player
{
	public class PlayerManager : MonoBehaviour
	{
		public static PlayerManager Instance { get; private set; }
		public GameObject _playerInstance { get; private set; }

		[SerializeField] private GameObject _playerPrefab;

		PlayerManager()
		{
			Instance = this;
		}
		


		public void SpawnPlayer(Vector3 pos, Vector3 scale, Color color, float speed, float cameraSize)
		{
			if (!_playerInstance)
			{
				_playerInstance = Instantiate(_playerPrefab);
				_playerInstance.transform.localScale = scale;
				_playerInstance.GetComponent<SpriteRenderer>().color = color;
				_playerInstance.GetComponent<PlayerController>().Speed = speed;
				Camera.main.orthographicSize = cameraSize;
			}
			TeleportPlayer(pos);
		}

		public void TeleportPlayer(Vector3 pos)
		{
			if (!_playerInstance) return;
			_playerInstance.transform.position = pos;
		}

		public void FreezePlayer()
		{
			_playerInstance.GetComponent<PlayerController>().Frozen = true;
		}

		public void UnfreezePlayer()
		{
			_playerInstance.GetComponent<PlayerController>().Frozen = false;
		}

	}
}
