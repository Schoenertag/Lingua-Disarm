using UnityEngine;
using System.Collections.Generic;

public class wall : MonoBehaviour {
	
	public Transform prefab1;
	public Transform prefab2;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition1;
	public Vector3 startPosition2;
	
	private Vector3 nextPosition1;
	private Vector3 nextPosition2;
	private Queue<Transform> objectQueue1;
	private Queue<Transform> objectQueue2;


	void Start () {
		objectQueue1 = new Queue<Transform>(numberOfObjects);
		nextPosition1 = startPosition1;
		for (int i = 0; i < numberOfObjects; i++) {
			Transform o = (Transform)Instantiate(prefab1);
			o.localPosition = nextPosition1;
			nextPosition1.z += o.localScale.z;
			objectQueue1.Enqueue(o);
		}

		objectQueue2 = new Queue<Transform>(numberOfObjects);
		nextPosition2 = startPosition2;
		for (int i = 0; i < numberOfObjects; i++) {
			Transform o = (Transform)Instantiate(prefab2);
			o.localPosition = nextPosition2;
			nextPosition2.z += o.localScale.z;
			objectQueue2.Enqueue(o);
		}
	}
	
	void Update () {
		if (objectQueue1.Peek().localPosition.z + recycleOffset < runner.distanceTraveled) {
			Transform o = objectQueue1.Dequeue();
			o.localPosition = nextPosition1;
			nextPosition1.z += o.localScale.z;
			objectQueue1.Enqueue(o);
		}

		if (objectQueue2.Peek().localPosition.z + recycleOffset < runner.distanceTraveled) {
			Transform o = objectQueue2.Dequeue();
			o.localPosition = nextPosition2;
			nextPosition2.z += o.localScale.z;
			objectQueue2.Enqueue(o);
		}
	}
}