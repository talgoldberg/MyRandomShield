using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionShield : MonoBehaviour
{

    public GameObject ShieldObj;//אובייקט המגן הרגיל
    private float Xlimit=1.5f;//שלא יחרוג לצד הכחול של המצלמה x-טווח בציר ה
    private float Ylimit=0.5f;//שלא יחרוג לצד התחתון/עליון של המצלמה y-טווח בציר ה
    private Vector2 ScreenBounds;//וקטור מיקום המצלמה
    
    // Start is called before the first frame update
    void Start()
    {   
        //מאותחל עם אורך והגובה שהוגדר עבור המצלמה
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        RandomPosition();
    }

    // Update is called once per frame
    void RandomPosition()
    {
        
        //מיקום רנדומלי עבור האובייקט עם הטווח שהגדרנו
         ShieldObj.transform.position = new Vector2(Random.Range(-ScreenBounds.x+Xlimit, ScreenBounds.x-Xlimit),Random.Range(-ScreenBounds.y+Ylimit, ScreenBounds.y-Ylimit));
    
       
    }
}
