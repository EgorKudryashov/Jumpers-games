using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject helpPanel;

    public void SelectFlyingBall()
    {
        SceneManager.LoadScene("FlyingBall");
    }

    public void SelectJumpToJob()
    {
        SceneManager.LoadScene("JumpToJob");
    }

    public void ShowHelpPanel()
    {
        helpPanel.SetActive(!helpPanel.activeSelf);
    }

}
