using UnityEngine;
using UnityEngine.UI;

public class runner : MonoBehaviour {

	private float loLim = 0.015F;
	private float hiLim = 0.13F;
	private int steps = 0;
	private bool stateH = false;
	private float fHigh = 8.0F;
	private float curAcc= 0F;
	private float fLow = 0.2F;
	private float avgAcc;

	public static float distanceTraveled;
	//public Text stepCounter;
	public int prevStep = 0;
	public bool running = false;
	public float stepTimer;
	public float speedTimer;
	public float speed;
	public float currTime;

    // gameobjects
    public GameObject pathManager;

	void Start() {
		currTime = Time.time;
		Debug.Log(currTime);
	}

    /*void OnTriggerEnter(Collider otherObj)
    {
        if (otherObj.name == "generation_point") {
            Debug.Log("hit wall obj");
            pathManager.GetComponent<path_generation>().CreateNewRoad();
        }
    }*/

    void Update () {
		// running stuff
		currTime = Time.time;
		Debug.Log(currTime);

		int currentStep = stepDetector();
		//stepCounter.GetComponent<Text>().text = speed.ToString();

		if(running == false){
			if(currentStep > prevStep){

				int stepDiff = currentStep - prevStep;

				if(stepDiff > 0.001 && currTime > 0.01){
					speed = (stepDiff / currTime) * 200;
				}
				else{
					speed = 0;
				}

				if(speed > 55){
					speed = 0;
				}

				currTime = Time.time;
				Debug.Log(currTime);

				transform.Translate(0f, 0f, speed * Time.deltaTime);
				distanceTraveled = transform.localPosition.z;
				prevStep = currentStep;
				running = true;
				stepTimer = Time.time;
				speedTimer = Time.time;
			}
			else{
				transform.Translate(0f, 0f, 0f);
				//stepCounter.GetComponent<Text>().text = "STOP MOVING!!!!!!!!!!";
			}
		}
		else{
			transform.Translate(0f, 0f, speed * Time.deltaTime);
			if(Time.time > (stepTimer + 0.005f))
				running = false;
		}

		// tilting stuff
		// *** coming soon ***
	}

	public int stepDetector(){
		curAcc = Mathf.Lerp (curAcc, Input.acceleration.magnitude, Time.deltaTime * fHigh);
		avgAcc = Mathf.Lerp (avgAcc, Input.acceleration.magnitude, Time.deltaTime * fLow);
		float delta = curAcc - avgAcc;
		if (!stateH) { 
			if (delta > hiLim) {
				stateH = true;
				steps++;
			} else if (delta < loLim) {
				stateH = false;
			}
			stateH = false;
		}
		avgAcc = curAcc;
		//calDistance (steps);
		
		return steps;
	}
}




	