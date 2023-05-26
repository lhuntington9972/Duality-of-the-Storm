using UnityEngine;

public class Shooting : MonoBehaviour
{
   public Camera m_Camera;

   public GameObject gun;

   void Update() {
       if (Input.GetMouseButtonDown(0)) {
           Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);

           if (Physics.Raycast(ray, out RaycastHit hit)) {
               if (hit.collider != null) {
                    Debug.Log("hit");
                }
           }
       }
   }
}