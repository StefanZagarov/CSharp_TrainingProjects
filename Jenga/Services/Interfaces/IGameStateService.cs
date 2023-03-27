using Model.State;
using ModelClasses;
using UnityEngine;

namespace Services.Interfaces
{
    public interface IGameStateService
    {
        GameState CreateGameState(User loggedUser, bool isGameOver);
    }
}