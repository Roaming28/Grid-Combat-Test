using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class LevelManager : MonoBehaviour{

    [SerializeField] private Image blackFade;

    [SerializeField] private GameObject preloadedRoom;
    [SerializeField] private GameObject startRoom;

    [SerializeField] private GameObject virtualCamera;

    private GameObject loadedRoom;

    void Start() {
        Destroy(preloadedRoom);
        loadedRoom = Instantiate(startRoom, transform);
        virtualCamera.transform.GetComponent<CinemachineConfiner>().m_BoundingShape2D = loadedRoom.transform.GetComponent<Room>().StartingCameraTrack;
    }

    public void hitDoor(GameObject door, GameObject caller) {
        //If door is unlocked
        if (!door.transform.GetComponent<Door>().Locked) {
            StartCoroutine(loadRoom(door, caller));
        }
    }

    //TODO: If necessary, make it so that the room can be loaded in another location and the player just moved to it without it reloading.
    // This is useful for if another character goes through the door.
    // Also, if another character uses a door, just leave them as a list to load in, next time the room loads in.
    private IEnumerator loadRoom(GameObject door, GameObject caller) {
        Door doorScript = door.transform.GetComponent<Door>();
        //Fade to black
        if(caller.tag == "Player") {
            caller.transform.GetComponent<CharacterController>().MovementEnabled = false;
            yield return StartCoroutine(fadeToBlack(1, 2));
        }
        //Set the character position
        Vector3 positionDelta = caller.transform.position;
        caller.transform.position = loadedRoom.transform.position + doorScript.DestinationDoor.transform.position + doorScript.DestinationDoor.transform.GetComponent<Door>().SpawnOffset;
        positionDelta -= caller.transform.position;
        //Reset the camera to the new area
        virtualCamera.transform.GetComponent<CinemachineConfiner>().m_BoundingShape2D = doorScript.DestinationDoor.transform.GetComponent<Door>().RelativeCameraTrack;
        virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().OnTargetObjectWarped(caller.transform, positionDelta);
        float tempX = virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping;
        float tempY = virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping;
        float tempZ = virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_ZDamping;
        virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 0;
        virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = 0;
        virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_ZDamping = 0;
        yield return new WaitForSeconds(0.2f);
        virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = tempX;
        virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = tempY;
        virtualCamera.transform.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_ZDamping = tempZ;
        //Fade back from black
        if(caller.tag == "Player") {
            yield return StartCoroutine(fadeToBlack(-1, 2));
            caller.transform.GetComponent<CharacterController>().MovementEnabled = true;
        }
    }

    private IEnumerator fadeToBlack(int direction, float fadeSpeed) {
        if(direction == 1){
            while(blackFade.GetComponent<Image>().color.a < 1) {
                Color objectColor = blackFade.GetComponent<Image>().color;
                blackFade.GetComponent<Image>().color = new Color(objectColor.r, objectColor.g, objectColor.b, objectColor.a + (fadeSpeed * Time.deltaTime));
                yield return null;
            }
        }else if (direction == -1) {
            while(blackFade.GetComponent<Image>().color.a > 0) {
                Color objectColor = blackFade.GetComponent<Image>().color;
                blackFade.GetComponent<Image>().color = new Color(objectColor.r, objectColor.g, objectColor.b, objectColor.a - (fadeSpeed * Time.deltaTime));
                yield return null;
            }
        }
        yield return null;
    }
}
