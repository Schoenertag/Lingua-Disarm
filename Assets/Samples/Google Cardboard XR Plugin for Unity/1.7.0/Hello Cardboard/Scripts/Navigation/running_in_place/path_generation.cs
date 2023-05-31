using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class path_generation : MonoBehaviour {

    public GameObject roadPrefab;
	public GameObject startBlock;
    public List<GameObject> currentRoads = new List<GameObject>();
	public int roadDrawDistance = 3;
    public int roadNum = 0;

    void Start(){
        

        // find already existing blocks of road and add them to the list
        GameObject[] existingRoads = GameObject.FindGameObjectsWithTag("road");

        foreach (GameObject road in existingRoads)
        {
            currentRoads.Add(road);
        }
        CreateNewRoad();

    }

	public void CreateNewRoad(){
        int listSize = currentRoads.Count;
        Debug.Log(listSize);

        // check how many blocks of road exist
        if (listSize > roadDrawDistance){
            Destroy(currentRoads[0]);
            currentRoads.RemoveAt(0);
		}

        listSize = currentRoads.Count;
        // make new block of road
        float blockLength = currentRoads[listSize - 1].transform.GetComponent<BoxCollider>().size.z;
        Vector3 blockPosition = currentRoads[listSize - 1].transform.position + new Vector3(0,0,blockLength);
        GameObject newRoad = (GameObject) Instantiate(roadPrefab, blockPosition, Quaternion.identity);
        roadNum += 1;
        newRoad.name = "Road" + roadNum;
        currentRoads.Add(newRoad);
    }


}
