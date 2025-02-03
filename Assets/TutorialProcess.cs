//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class TutorialProcess : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update

    [SerializeField] private float[] waitTime;
    [SerializeField] GameObject[] textImageObjects;

    [SerializeField] KeyCode[] keyCodeA;
    [SerializeField] KeyCode[] keyCodeB;
    
    
    private int processIndex = 0;
    private float timeCounting = 0;

    void Start()
    {
        player.GetComponent<Transform>().position = new Vector3(9, 17, 0);
		foreach (var item in textImageObjects)
		{
			item.gameObject.SetActive(false);
		}


	}

    // Update is called once per frame
    void Update()
    {
        //if (processIndex < waitTime.Length && waitTime[processIndex] < timeCounting)
        //{
			
        //}

		MoveTutorial();
		timeCounting += Time.deltaTime;
        Debug.Log(processIndex);
	}

    private void MoveTutorial()
    {
        if (processIndex >= keyCodeA.Length) return;

		textImageObjects[processIndex].gameObject.SetActive(true);

		if (Input.GetKeyDown(keyCodeA[processIndex]) || Input.GetKeyDown(keyCodeA[processIndex]))
        {
            processIndex++;
            foreach (var item in textImageObjects)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

	private void ResetTime()
	{
		timeCounting = 0;
	}
}
