using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

	Light lighting;

	private float lightningCooldown;
	private float lightningDuration;

	public AudioSource lightningNoise1;
	public AudioSource lightningNoise2;
	public AudioSource lightningNoise3;

	private AudioSource lightningNoise;
	private int lightningPicker;

	// Use this for initialization
	void Start()
	{
		lighting = GetComponent<Light>();
		lighting.enabled = false;
		lightningCooldown = 5f;
		lightningDuration = 0.2f;
		StartCoroutine(Lightnings());
	}

	// Update is called once per frame
	void Update()
	{
		// Toggle light on/off when L key is pressed.
		if (Input.GetKeyUp(KeyCode.L))
		{
			lighting.enabled = !lighting.enabled;
		}
	}

	IEnumerator Lightnings()
    {
		for (int i = 0; i < 5; i++)
		{
			yield return new WaitForSeconds(lightningCooldown);
			lighting.enabled = !lighting.enabled;
			lightningPicker = Random.Range(1, 4);
			if (lightningPicker == 1)
			{
				lightningNoise = lightningNoise1;
			}
			else if (lightningPicker == 2)
			{
				lightningNoise = lightningNoise2;
			} else if (lightningPicker == 3)
            {
				lightningNoise = lightningNoise3;
            }
			lightningNoise.Play(0);
			yield return new WaitForSeconds(lightningDuration);
			lighting.enabled = !lighting.enabled;
		}
    }
}