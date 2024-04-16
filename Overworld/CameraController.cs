using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    [SerializeField] private GameObject tracking;
    
    private LineRenderer currentTrack;
    public LineRenderer CurrentTrack { get => currentTrack; set => currentTrack = value; }


    /*
    void Update() {
        float dx = tracking.transform.position.x;
        float dy = tracking.transform.position.y;

        if(currentTrack != null) {
            //With a gradient of 0, the line formula is y = b from the x of the camera to the right
            RaycastHit2D rayX = RayCast(new Vector3(dx, transform.position.y, 0));
            RaycastHit2D rayY = RayCast(new Vector3(transform.position.x, dy, 0));
            //Counts on the line renderer being a closed loop for now
            int xIntersections = 0;
            int yIntersections = 0;
            for (int i=0; i<currentTrack.GetPosition().GetLength(); i++) {
                Vector3 p1 = currentTrack.GetPosition(i);
                Vector3 p2 = currentTrack.GetPosition(i+1);


            }

            if (!currentTrack.bounds.Contains(new Vector3(dx, transform.position.y, 0))) {
                dx = 0;
            }
            if (!currentTrack.bounds.Contains(new Vector3(transform.position.x, dy, 0))) {
                dy = 0;
            }
        }

        transform.position = new Vector3(dx, dy, -10);
    }
    */
}
