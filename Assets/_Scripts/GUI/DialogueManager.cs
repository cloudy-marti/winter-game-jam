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
		private Image _leftSpeaker;
		private Image _rightSpeaker;
		private CanvasGroup _canvasGroup;

		private string[] _speakers;
		private string[] _speeches;
		private Sprite[] _faces;
		private uint[] _facesOrder;

		private uint _faceOrderIndex = 0;

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
			_rightSpeaker = _dialogPrefabInstance.transform.Find("RightSpeaker").GetComponent<Image>();
			_leftSpeaker = _dialogPrefabInstance.transform.Find("LeftSpeaker").GetComponent<Image>();
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
				_faceOrderIndex = 0;
				_inDialogue = false;
				return;
			}

			_speakerText.text = _speakers[_dialogueIndex];
			_diagText.text = _speeches[_dialogueIndex];

			if (_faceOrderIndex % 2 == 0)
				_leftSpeaker.sprite = _faces[_facesOrder[_faceOrderIndex]];
			else
				_rightSpeaker.sprite = _faces[_facesOrder[_faceOrderIndex]];

			++_faceOrderIndex;
			++_dialogueIndex;
		}

		public void Show(string[] speakers, string[] speeches, Sprite[] faces, uint[] facesOrder)
		{
			if (speakers.Length != speeches.Length && speeches.Length != facesOrder.Length) return;

			_speakers = speakers;
			_speeches = speeches;
			_faces = faces;
			_facesOrder = facesOrder;

			_speakerText.text = _speakers[_dialogueIndex];
			_diagText.text = _speeches[_dialogueIndex];
			++_dialogueIndex;

			_leftSpeaker.sprite = faces[facesOrder[_faceOrderIndex]];
			++_faceOrderIndex;

			PlayerManager.Instance.FreezePlayer();
			_canvasGroup.DOFade(1f, 0.1f);
			_inDialogue = true;
		}
	}
}
