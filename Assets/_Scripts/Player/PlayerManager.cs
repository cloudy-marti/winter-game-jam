using JetBrains.Annotations;
using UnityEngine;

namespace _Scripts.Player
{
	public class PlayerManager : MonoBehaviour
	{
		public static PlayerManager Instance { get; private set; }
		private GameObject _playerInstance;

		[SerializeField] private GameObject _playerPrefab;

		PlayerManager()
		{
			Instance = this;
		}
		
		public void SpawnPlayer(Vector3 pos)
		{
			if (!_playerInstance)
			{
				_playerInstance = Instantiate(_playerPrefab);
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
