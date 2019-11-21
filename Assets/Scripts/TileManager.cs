using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
	public GameObject[] tilePrefabs;
	private Transform playerTranform;
	private float spawnz = -6.254f;
	private float tileLength = 15.254f;
	private int amtTilesOnScreen = 3;
	private List<GameObject> activeTiles;
	private float safeZone = 20.0f;

	private int lastPrefabIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
    	activeTiles = new List<GameObject>();
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i=0;i<amtTilesOnScreen;i++)
        {
        	//Spwans only normal bridge at the first instance of the game
        	if(i<2)
        	{
        		SpawnTile(0);
        	}
        	else
        	{
        		SpawnTile();
        	}        	
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(playerTranform.position.z - safeZone> (spawnz - amtTilesOnScreen * tileLength))
        {
        	SpawnTile();
        	RemoveTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
    	GameObject go;
    	if(prefabIndex==-1)
    	{
    		go = Instantiate(tilePrefabs [RandomPrefabIndex()]) as GameObject;
    	}
    	else
    	{
    		go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
    	}
    	go.transform.SetParent(transform);
    	go.transform.position = Vector3.forward * spawnz;
    	spawnz += tileLength;
    	activeTiles.Add(go);
    }

    private void RemoveTile()
    {
    	Destroy(activeTiles[0]);
    	activeTiles.RemoveAt(0);
    }

    //random generates indexes of tile prefabs to load on scene
    private int RandomPrefabIndex()
    {
    	if(tilePrefabs.Length<=1)
    		return 0;

    	int randomIndex = lastPrefabIndex;
    	while(randomIndex == lastPrefabIndex)
    	{
    		randomIndex = Random.Range(0, tilePrefabs.Length);
    	}
    	lastPrefabIndex = randomIndex;
    	return randomIndex;
    }
}
