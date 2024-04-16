using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Room : MonoBehaviour{

    [SerializeField] private PolygonCollider2D startingCameraTrack;

    public PolygonCollider2D StartingCameraTrack { get => startingCameraTrack; set => startingCameraTrack = value; }
}
