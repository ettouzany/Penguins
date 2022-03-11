using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{

    [SerializeField] private Transform player;
    TerrainCollider terrainCollider;
    [SerializeField] GameObject childInit;
    List<child> mapChildren;
    Vector3 worldPosition;
    Ray ray;
    void Start()
    {
        mapChildren = new List<child>();
        terrainCollider = Terrain.activeTerrain.GetComponent<TerrainCollider>();

        InvokeRepeating("CallMe", 2.0f, 1f);
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;
        if (terrainCollider.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
        }
        player.position = Vector3.MoveTowards(player.position, new Vector3(hitData.point.x, player.position.y, hitData.point.z),  
            Time.deltaTime*7);
        player.transform.LookAt(hitData.point);
    }
    public void CallMe()
    {
        GameObject newChild = GiveMeAChildInARanomPos(childInit, 100, 10);
        newChild.AddComponent<child>();
        newChild.GetComponent<child>().player = player.GetComponent<Player>();
        mapChildren.Add(newChild.GetComponent<child>());
    }    
    public GameObject GiveMeAChildInARanomPos(GameObject child, int max, int min)
    {
        return Instantiate(child, new Vector3(Random.Range(min, max), 0, Random.Range(min, max)),new Quaternion(0,0,0,0));
    }
}
