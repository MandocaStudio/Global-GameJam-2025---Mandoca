using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public GameObject fadePanel;
    public float fadeInDuration = 1f;
    public float fadeOutDuration = 0.5f;

    private Image panelImage;

    private void Start()
    {

        panelImage = fadePanel.GetComponent<Image>();
        SetPanelAlpha(0);

        StartCoroutine(FadeSequence());

    }



    private IEnumerator FadeSequence()
    {

        yield return StartCoroutine(FadeIn());


        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        float elapsed = 0f;

        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeInDuration);
            SetPanelAlpha(alpha);
            yield return null;
        }

        SetPanelAlpha(1);
    }

    public IEnumerator FadeOut()
    {
        float elapsed = 0f;

        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(1 - (elapsed / fadeOutDuration));
            SetPanelAlpha(alpha);
            yield return null;
        }

        SetPanelAlpha(0);
    }

    private void SetPanelAlpha(float alpha)
    {
        if (panelImage != null)
        {
            Color color = panelImage.color;
            color.a = alpha;
            panelImage.color = color;
        }
    }
}
