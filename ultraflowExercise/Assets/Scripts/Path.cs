using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Path : MonoBehaviour {
    /** This is the path **/
    public Transform[] points;
    /* If true, draw the path in the scene in order to check */
    public bool draw_path = true;

    /* I choose to return the Enumerator because i want this type of path :
     * 1-2-3  then 3-2-1 ,instead of returning simply the points array. 
     */
    public IEnumerator<Transform> get_path_enumerator() { 
        if(points==null || points.Length<1)
            yield break;

        int direction = 1;  //forward or backward?
        int index = 0;      //current index
        
        /* Thanks to the yield, the loop will ends if the owner of the scripts die. Prevents nullreferenceex*/
        while (true)
        {
            yield return points[index];
            
            if (points.Length == 1)
                continue;

            if (index <= 0)
                direction = 1;
            else
                if (index >= points.Length - 1)
                    direction = -1;

            index = index + direction;
        }
    }

    

    

}
