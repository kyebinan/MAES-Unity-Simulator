using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogoSequence : MonoBehaviour
{
    public Image[] logos; // Tes logos dans l'ordre
    public float fadeDuration = 1.0f;
    public float displayDuration = 1.5f;

    private int currentLogo = 0;

    void Start()
    {
        // S'assurer que tous les logos sont invisibles au départ
        foreach (var logo in logos)
        {
            var color = logo.color;
            color.a = 0;
            logo.color = color;
        }

        ShowNextLogo();
    }

    void ShowNextLogo()
    {
        if (currentLogo >= logos.Length)
        {
            // Fin de la séquence -> charger la scène suivante
            SceneManager.LoadScene("MenuScene"); // remplace par ta scène principale
            return;
        }

        Image logo = logos[currentLogo];

        // Fade in
        LeanTween.alpha(logo.rectTransform, 1f, fadeDuration).setOnComplete(() =>
        {
            // Attendre un moment
            LeanTween.delayedCall(displayDuration, () =>
            {
                // Fade out
                LeanTween.alpha(logo.rectTransform, 0f, fadeDuration).setOnComplete(() =>
                {
                    currentLogo++;
                    ShowNextLogo();
                });
            });
        });
    }
}
