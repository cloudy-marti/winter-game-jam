using System.Collections;
using DG.Tweening;
using UnityEngine;
using _Scripts.Diags;
using _Scripts.GUI;
using _Scripts.Player;

namespace _Scripts
{
	public class EndAnimation : MonoBehaviour
	{
		[SerializeField] private ScriptableDialogue[] _diags;
		[SerializeField] private GameObject _oldLink;

		IEnumerator EndCorroutine()
		{
			GameObject playerInstance = PlayerManager.Instance._playerInstance;

			DialogueManager.Instance.Show(_diags[0].Speakers, _diags[0].Speeches, _diags[0].Faces, _diags[0].FacesOrder);

			PlayerManager.Instance.FreezePlayer();

			GameObject instance = Instantiate(_oldLink, new Vector3(0f, -5f, -5), Quaternion.identity);
			instance.GetComponent<Animator>().enabled = true;
			instance.GetComponent<Animator>().Play("Up");
			instance.transform.DOMove(new Vector3(-0.5f, -1f, -5), 2f).SetEase(Ease.Linear).OnComplete(() =>
			{
				StartCoroutine(PapyComes(playerInstance, instance));
			});
			yield return null;
		}

		IEnumerator PapyComes(GameObject playerInstance, GameObject instance)
		{
			DialogueManager.Instance.Show(_diags[1].Speakers, _diags[1].Speeches, _diags[1].Faces, _diags[1].FacesOrder);
			instance.SetActive(true);
			instance.GetComponent<Animator>().enabled = false;
			instance.GetComponentInChildren<SpriteRenderer>().enabled = true;
			yield return new WaitUntil(() => DialogueManager.DialogueFinish);
			PlayerManager.Instance.FreezePlayer();
			Camera.main.transform.position = instance.transform.position;
			playerInstance.transform.DOMove(new Vector3(0f, -5f, -10), 2f).SetEase(Ease.Linear).OnComplete(() =>
			{
				StartCoroutine(LinkGoes(playerInstance, instance));
			});
			yield return null;
		}


		IEnumerator LinkGoes(GameObject playerInstance, GameObject instance)
		{
			DialogueManager.Instance.Show(_diags[2].Speakers, _diags[2].Speeches, _diags[2].Faces, _diags[2].FacesOrder);
			yield return new WaitUntil(() => DialogueManager.DialogueFinish);

			instance.GetComponent<Animator>().enabled = true;
			instance.GetComponent<Animator>().Play("Down");
			PlayerManager.Instance.FreezePlayer();
			instance.SetActive(false);
			instance.transform.DOMove(new Vector3(-0.5f, -1f, -5), 2f).SetEase(Ease.Linear).OnComplete(Application.Quit);
		}


		public void PlayEndAnimation()
		{
			StartCoroutine(EndCorroutine());
		}
	}
}
