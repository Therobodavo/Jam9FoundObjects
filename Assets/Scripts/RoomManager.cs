﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject startRoom;
    private GameObject lastRoom;

    // Start is called before the first frame update
    void Start()
    {
        lastRoom = startRoom;
        GenRoom();
        GenRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenRoom()
    {
        Vector3 newRoomPos = lastRoom.transform.position;
        newRoomPos.y += 11.32f;
        lastRoom = Instantiate(roomPrefab, newRoomPos, Quaternion.identity);
    }
}