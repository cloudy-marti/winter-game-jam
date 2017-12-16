using UnityEngine;
using _Scripts.GUI;
using _Scripts.ItemDescription;

namespace _Scripts.Objects
{
	public class InteractiveObject : MonoBehaviour
	{
		[SerializeField] private ScriptableDialogue _dialogue;

		public void Interact()
		{
			DialogueManager.Instance.Show(_dialogue.Speakers, _dialogue.Speeches, _dialogue.Faces, _dialogue.FacesOrder);
		}
	}
}
