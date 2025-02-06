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


	[SerializeField] private int processIndex = 0;
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
        if (processIndex < waitTime.Length && waitTime[processIndex] < timeCounting)
        {
            MoveTutorial();
        }

		timeCounting += Time.deltaTime;
	}

    private void MoveTutorial()
    {
		textImageObjects[processIndex].gameObject.SetActive(true);

        if (processIndex >= keyCodeA.Length) return;

		if (Input.GetKeyDown(keyCodeA[processIndex]) || Input.GetKeyDown(keyCodeA[processIndex]))
        {
            foreach (var item in textImageObjects)
            {
                item.gameObject.SetActive(false);
            }
            
            processIndex++;
            ResetTime();
        }
    }

	private void ResetTime()
	{
		timeCounting = 0;
	}
}
