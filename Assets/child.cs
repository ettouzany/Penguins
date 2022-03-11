using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class child : MonoBehaviour
{
    public Player player;
    public GameObject tofollow;
    void Update()
    {
        if (tofollow == null)
        {
            foreach (child child in player.MyChildren)
            {
                if (Vector3.Distance(transform.position, child.transform.position) < 2f)
                {
                    tofollow = player.MyChildren.Last().gameObject;
                    player.MyChildren.Add(this);
                    break;
                }
            }
            if (tofollow == null)
                if (Vector3.Distance(transform.position, player.transform.position) < 2f)
                {
                    if(player.MyChildren.Count > 0)
                        tofollow = player.MyChildren.Last().gameObject;
                    else
                        tofollow = player.gameObject;

                    player.MyChildren.Add(this);
                }
        }
        else if (Vector3.Distance(transform.position,tofollow.transform.position) > 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(tofollow.transform.position.x, transform.position.y, tofollow.transform.position.z),
            Time.deltaTime * 7);
            transform.LookAt(tofollow.transform);
        }
        else
        {
            transform.LookAt(tofollow.transform);
        }
    }
}
