using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{

	Light lighting;

	private float lightningCooldown;
	private float lightningDuration;

	public AudioSource lightningNoise;

	// Use this for initialization
	void Start()
	{
		lighting = GetComponent<Light>();
		lighting.enabled = false;
		lightningCooldown = 10f;
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
			lightningNoise.Play(0);
			yield return new WaitForSeconds(lightningDuration);
			lighting.enabled = !lighting.enabled;
		}
    }
}