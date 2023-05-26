using UnityEngine;

public class Shooting : MonoBehaviour
{
   public Camera m_Camera;

   public GameObject gun;

   public Color c1 = Color.yellow;
   public Color c2 = Color.red;
   public int lengthOfLineRenderer = 20;

   LineRenderer lineRenderer;

   void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.01f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
    }

   void Update() {
       if (Input.GetMouseButtonDown(0)) {
           Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);

           if (Physics.Raycast(ray, out RaycastHit hit)) {
               if (hit.collider != null) {
                    Debug.Log("hit");

                    LineRenderer lineRenderer = GetComponent<LineRenderer>();
                    Vector3[] points = {m_Camera.transform.position, hit.point};
                    
                    lineRenderer.SetPositions(points);
                }
           }
       }
   }
}