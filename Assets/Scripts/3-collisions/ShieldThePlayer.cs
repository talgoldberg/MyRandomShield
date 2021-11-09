using System.Collections;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
        
    public GameObject MyCircleShield;//אובייקט חדש שהוספתי עיגול מגן סביב החללית
    
  


    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            MyCircleShield.SetActive(true);//בעת התנגשות עם המגן הרגיל מופעל המגן הזוהר
            
            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent));
                // NOTE: If you just call "StartCoroutine", then it will not work, 
                //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }
    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {
        destroyComponent.enabled = false;
        
        for (float i = duration; i > 0; i--) {//שנותן הרגשה שהמגן נחלש אחרי כמה שניות sprite הוספת 
         
            Debug.Log("Shield: " + i + " seconds remaining!");
            if(i==3)
            MyCircleShield.GetComponent<SpriteRenderer>().sprite = MyCircleShield.GetComponent<UpdatePos>().secondshield;

            if(i==1)
            MyCircleShield.GetComponent<SpriteRenderer>().sprite = MyCircleShield.GetComponent<UpdatePos>().thirdshield;

            yield return new WaitForSeconds(1);
        }
        Debug.Log("Shield gone!");
        
        destroyComponent.enabled = true;
        MyCircleShield.SetActive(false);//מפסיק את נראות המגן הזוהר לאחר 5 שניות
        Destroy(MyCircleShield);//הורס את האובייקט החדש
        
        
        
    }
}
