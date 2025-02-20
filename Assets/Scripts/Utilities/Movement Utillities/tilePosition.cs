using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePosition : MonoBehaviour
{


    public Vector3 GetTilePosition()
    {
        return new Vector3(transform.position.x, 0,transform.position.z);
    }


}