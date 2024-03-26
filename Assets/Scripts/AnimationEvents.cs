using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private GameObject skillSelectPanel;
    [SerializeField] private GameObject fadeImage;
    [SerializeField] private GameObject skillAttributionPanel;
    [SerializeField] private GameObject namesPanel;
    [SerializeField] private GameObject playerOverviewPanel;
    [SerializeField] private GameObject introFadeImage;

    public void SkillSelectPanelOn()
    {
        skillSelectPanel.SetActive(true);
    }

    public void SkillAttributionPanelOn()
    {
        skillAttributionPanel.SetActive(true);
        skillSelectPanel.SetActive(false);
    }

    public void NamesPanelOn()
    {
        namesPanel.SetActive(true);
        skillAttributionPanel.SetActive(false);
    }

    public void PlayerOverviewPanelOn()
    {
        playerOverviewPanel.SetActive(true);
        namesPanel.SetActive(false);
    }

    public void PlayerOverviewPanelOff()
    {
        playerOverviewPanel.SetActive(false);
        fadeImage.SetActive(false);
        FindObjectOfType<TimePassing>().isPaused = false;
        EnableCamera();
    }

    public void IntroFadeOff()
    {
        introFadeImage.SetActive(false);
    }

    public void EnableCamera()
    {
        FindObjectOfType<CameraController>().isActive = true;
    }
}
