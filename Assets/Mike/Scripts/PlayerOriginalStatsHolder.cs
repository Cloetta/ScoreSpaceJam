using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class PlayerOriginalStatsHolder : MonoBehaviour
{
    //copies and replace scriptable stats of the playerç copy at the beginning og the scene + replace with clone
    //then, destroys clone of scriptable object 

    private void Start()
    {
        var clone = Instantiate(GetComponent<PlayerController>()._stats);
        GetComponent<PlayerController>()._stats = clone;
    }

}
