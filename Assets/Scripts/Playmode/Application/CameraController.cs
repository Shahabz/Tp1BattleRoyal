﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private float minimumCameraSize = 10;
	[SerializeField] private float shrinkingSpeedPerSeconds;
	private float currentCameraSizeGoal;
	private int numberOfEnnemyAtStart;

	private void Start()
	{
		currentCameraSizeGoal = Camera.main.orthographicSize;
	}
	public void OnDeath()
	{
		//todo: subscribe to ondeath event in ennemies and shrink camera every time
		Shrink(Camera.main.orthographicSize/numberOfEnnemyAtStart);
		
	}

	private void Shrink(float sizeToSubstract)
	{
		if (currentCameraSizeGoal != minimumCameraSize)
			currentCameraSizeGoal -= sizeToSubstract;
		if (currentCameraSizeGoal < minimumCameraSize)
			currentCameraSizeGoal= minimumCameraSize;
	}

	private void Update()
	{
		if (currentCameraSizeGoal <= Camera.main.orthographicSize)
		{
			Camera.main.orthographicSize -= shrinkingSpeedPerSeconds * Time.deltaTime;
		}
	}
}
