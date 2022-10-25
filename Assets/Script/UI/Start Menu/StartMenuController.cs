using System.IO;
using Game_Manager;
using PixelCrushers;
using UnityEngine;

namespace Script.UI.Start_Menu
{
    
    
    public class StartMenuController : MonoBehaviour
    {
        public void StartNewGame()
        {
            SaveManager.InitializeData();
            SaveSystem.ResetGameState();
            SaveSystem.LoadScene("City@New Game Spawn Position");
        }

        public void ContinueGame()
        {
            if (!(File.Exists(SaveManager.BattleDataFilePath) && File.Exists(SaveManager.AbilityDataFilePath)))
            {
                return;
            }
            
            SaveSystem.LoadFromSlot(0);
        }
    }
}
