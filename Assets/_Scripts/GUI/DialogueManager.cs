using System.Collections;
using DG.Tweening;
using DG.Tweening.Plugins;
using UnityEngine;
using UnityEngine.UI;
using _Scripts.Player;

namespace _Scripts.GUI
{
	public class DialogueManager : MonoBehaviour
	{
		public static DialogueManager Instance { get; private set; }

		[SerializeField] private GameObject _dialogPrefab;
		private GameObject _dialogPrefabInstance;
		private Text _diagText;
		private Text _speakerText;
		private CanvasGroup _canvasGroup;

		private string[] _speakers;
		private string[] _speeches;

		private int _dialogueIndex = 0;
		private bool _inDialogue = false;

		DialogueManager()
		{
			Instance = this;
		}

		// Use this for initialization
		void Start ()
		{
			_dialogPrefabInstance = Instantiate(_dialogPrefab);
			_dialogPrefabInstance.transform.SetParent(transform);
			_canvasGroup = _dialogPrefabInstance.GetComponent<CanvasGroup>();
			_diagText = _dialogPrefabInstance.transform.Find("DiagBackground/DiagText").GetComponent<Text>();
			_speakerText = _dialogPrefabInstance.transform.Find("DiagBackground/SpeakerBackground/SpeakerText").GetComponent<Text>();
		}

		public void Update()
		{

			if (!Input.GetKeyDown(KeyCode.Space)|| !_inDialogue) return;

			if (_inDialogue && _dialogueIndex == _speakers.Length)
			{
				_speakerText.text = "";
				_diagText.text = "";
				_canvasGroup.DOFade(0f, 0.1f);
				PlayerManager.Instance.UnfreezePlayer();
				_dialogueIndex = 0;
				_inDialogue = false;
				return;
			}

			_speakerText.text = _speakers[_dialogueIndex];
			_diagText.text = _speeches[_dialogueIndex];
			++_dialogueIndex;
		}

		public void Show(string[] speakers, string[] speeches)
		{
			if (speakers.Length != speeches.Length) return;
			_speakers = speakers;
			_speeches = speeches;

			_speakerText.text = _speakers[_dialogueIndex];
			_diagText.text = _speeches[_dialogueIndex];
			++_dialogueIndex;

			PlayerManager.Instance.FreezePlayer();
			_canvasGroup.DOFade(1f, 0.1f);
			_inDialogue = true;
		}
	}
}
