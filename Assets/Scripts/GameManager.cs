using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public CR cr;

    [SerializeField] CanvasGroup tutorialHUD;
    [SerializeField] RectTransform playButton;
    [SerializeField] Transform logo;

    private TextMeshProUGUI tutorialDescription;
    public void Awake()
    {
        cr = GameObject.FindWithTag("Player").GetComponent<CR>();
        tutorialDescription = tutorialHUD.transform.Find("description").GetComponent<TextMeshProUGUI>();
    }
    public void GameStart()
    {
        logo.GetComponent<Animator>().SetTrigger("Start");
        StartCoroutine(StartTween());
    }
    IEnumerator StartTween()
    {
        float duration = 0.7f;
        var ease = Ease.InCubic;
        logo.DOMoveY(6f, duration).SetEase(ease);
        playButton.DOAnchorPosY(-40f, duration).SetEase(ease);

        yield return new WaitForSeconds(duration);

        Destroy(logo.gameObject);
        Destroy(playButton.gameObject);
        cr.transform.DOMoveY(-3f, 1f).SetEase(Ease.OutCirc);
        Camera.main.DOOrthoSize(6.6f, 1f).SetEase(Ease.OutCirc);

        yield return new WaitForSeconds(1f);
        StartCoroutine(Tutorial());
    }

    public IEnumerator ChangeCanvasGroupAlpha(CanvasGroup group, float duration, float destination)
    {
        if (group == null) yield break;
        float t = 0;
        while ( t < duration )
        {
            t += Time.deltaTime;
            group.alpha = t / duration * destination;
            yield return null;
        }
    }
    IEnumerator Tutorial()
    {
        tutorialDescription.text = $"방향키를 눌러 움직입니다";
        yield return ChangeCanvasGroupAlpha(tutorialHUD, 1.2f, 1f);
    }
}
