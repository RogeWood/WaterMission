//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSenceButtonController : MonoBehaviour
{
    [SerializeField] GameObject controllDiscribePanel;

	[SerializeField] RectTransform startbuttonRectTransform;
	[SerializeField] RectTransform closebuttonRectTransform;

	private void Awake()
	{
		Time.timeScale = 0f;
	}

	// Start is called before the first frame update
	void Start()
    {
        Time.timeScale = 1f;
        controllDiscribePanel.SetActive(false);
    }

    //// Update is called once per frame
    void Update()
    {
        // mouse move on button



        // close controll discribe panel
        if (controllDiscribePanel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
            {
                controllDiscribePanel.SetActive(false);
            }
        }
    }


    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OnClickCloseGame()
    {
        Application.Quit();
    }

    public void OnClickControllDiscribePanel()
    {
        controllDiscribePanel.SetActive(true);
    }
}
