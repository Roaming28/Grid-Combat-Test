using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    [SerializeField] private GameObject destinationDoor;
    [SerializeField] private Vector3 spawnOffset;

    [SerializeField] private PolygonCollider2D relativeCameraTrack;

    private bool locked = false;

    public GameObject DestinationDoor { get => destinationDoor; set => destinationDoor = value; }
    public Vector3 SpawnOffset { get => spawnOffset; set => spawnOffset = value; }
    
    public bool Locked { get => locked; set => locked = value; }
    public PolygonCollider2D RelativeCameraTrack { get => relativeCameraTrack; set => relativeCameraTrack = value; }
}
