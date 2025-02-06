//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonController : MonoBehaviour
{
	[SerializeField] private GameObject pausePanel;

	private void Start()
	{
		pausePanel.SetActive(false);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			OnClickESC();
	}
	public void OnClickESC()
	{
		pausePanel.SetActive(true);
	}
}
