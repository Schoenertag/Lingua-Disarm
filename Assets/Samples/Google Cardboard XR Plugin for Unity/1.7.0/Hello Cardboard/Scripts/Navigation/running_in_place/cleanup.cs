using UnityEngine;

public class cleanup : MonoBehaviour {

	void Start () {
		foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>()){
			if(gameObj.name == "Cardboard"){
				gameObj.SetActive(false);
			}
		}
	}
}