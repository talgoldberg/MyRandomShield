using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePos : MonoBehaviour
{   
    
    public GameObject player;//אובייקט החללית
    public Sprite secondshield;//מגן חדש שנחלש
    public Sprite thirdshield;//מגן חדש שנחלש יותר
   
    

    // Start is called before the first frame update

    void Start()
    {
      
       this.gameObject.SetActive(false);//לא פעיל עד להתנגשות עם המגן הרגיל
      
    }

    // Update is called once per frame
    void Update()
    {
      
        this.transform.position = player.transform.position;//מיקום המגן הזוהר (אובייקט) מתעדכן עם מיקום החללית
    }
}
