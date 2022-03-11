using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update


    // Update is called once per frame
    //void Update()
    //{
    //    if(Vector3.Distance(new Vector3(transform.position.x,0, transform.position.z), new Vector3(player.position.x, 0, player.position.z) ) >= 20f)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, player.position.z), 5 * Time.deltaTime);
    //    }
    //}
    [SerializeField] Vector3 offset;
    //private void Start()
    //{
    //    offset = transform.position;
    //}
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x,0,player.position.z) + offset;
    }
}
