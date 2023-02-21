using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGO;
    [SerializeField] private Image barImage;

    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGO.GetComponent<IHasProgress>();
        if (hasProgress == null)
            Debug.LogError("Game Object " + hasProgressGO + " does not have a component that implements IHasProgress!");

        hasProgress.OnProgressChanged += OnProgressChanged;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void OnApplicationQuit()
    {
        hasProgress.OnProgressChanged -= OnProgressChanged;
    }

    private void OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;

        if (e.progressNormalized == 0f || e.progressNormalized == 1f)
            Hide();
        else
            Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}