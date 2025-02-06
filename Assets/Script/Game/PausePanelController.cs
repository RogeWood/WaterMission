//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
	[SerializeField] GameObject pauseMenuPanel;
	[SerializeField] GameObject settingPanel;
	[SerializeField] GameObject targetPanel;

	[SerializeField] GameObject[] teacherTutorialImages;

    private int tutorialImageIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
		foreach (GameObject go in teacherTutorialImages)
		{
			go.SetActive(false);
		}
		targetPanel.SetActive(false);
        settingPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
		tutorialImageIndex = 0;

		teacherTutorialImages[tutorialImageIndex].SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingPanel.activeSelf)
                OnClickCloseSetting();
			else if (pausePanel.activeSelf)
                pausePanel.SetActive(false);
        }


        TeacherTutorial();
    }
    private void TeacherTutorial()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            foreach(GameObject go in teacherTutorialImages)
            {
                go.SetActive(false);
            }
            teacherTutorialImages[tutorialImageIndex].SetActive(true);

            tutorialImageIndex++;
            if (tutorialImageIndex >= teacherTutorialImages.Length) tutorialImageIndex = 0;
        }
    }

    public void OnClickButtonBackToGame()
    {
        pausePanel.SetActive(false);
    }

    public void OnClickButtonBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickSetting()
	{
		pauseMenuPanel.SetActive(false);
		targetPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void OnClickCloseSetting()
	{
		pauseMenuPanel.SetActive(true);
		targetPanel.SetActive(false);
		settingPanel.SetActive(false);
    }

	public void OnClickTarget()
	{
		pauseMenuPanel.SetActive(false);
		targetPanel.SetActive(true);
		settingPanel.SetActive(false);
	}

}
