﻿using UnityEngine;
using System.Collections.Generic;

public class path : MonoBehaviour {
	
	public Transform prefab;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	
	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;
	
	void Start () {
		objectQueue = new Queue<Transform>(numberOfObjects);
		nextPosition = startPosition;
		for (int i = 0; i < numberOfObjects; i++) {
			Transform o = (Transform)Instantiate(prefab);
			o.localPosition = nextPosition;
			nextPosition.z += o.localScale.z;
			objectQueue.Enqueue(o);
		}
	}
	
	void Update () {
		if (objectQueue.Peek().localPosition.z + recycleOffset < runner.distanceTraveled) {
			Transform o = objectQueue.Dequeue();
			o.localPosition = nextPosition;
			nextPosition.z += o.localScale.z;
			objectQueue.Enqueue(o);
		}
	}
}