using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Model.State;
using Services.Interfaces;
using ModelClasses;
using System;
using System.Globalization;

namespace Services
{
    public class GameStateService : IGameStateService
    {
        public GameState CreateGameState(User loggedUser, bool isGameOver)
        {
            List<GameObject> bricksList = GameObject.FindGameObjectsWithTag("Brick").ToList();
            List<BrickState> brickStateList = new();

            foreach (GameObject brick in bricksList)
            {
                Color brickColor = brick.GetComponent<Renderer>().material.color;
                float[] colors = { brickColor[0], brickColor[1], brickColor[2] };

                BrickState brickState = new(brick.transform.position.x, brick.transform.position.y, brick.transform.position.z,
                    brick.transform.rotation.x, brick.transform.rotation.y, brick.transform.rotation.z, brick.transform.rotation.w,
                     colors);

                brickStateList.Add(brickState);
            }

            CameraState cameraState = new(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z,
                Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);

            GameState gameState = new()
            {
                BrickStates = brickStateList,
                CameraPosition = cameraState,
                AccountName = loggedUser.Username,
                TimeOfSave = "Saved\n" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                IsGameOver = isGameOver
            };

            return gameState;
        }
    }
}