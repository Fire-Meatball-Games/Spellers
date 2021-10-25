using UnityEngine.UI;
using UnityEngine;
using Runtime;

public class LevelSelector : MonoBehaviour
{
    private LevelInfo levelInfo;

    public Text levelNameText, levelNumberText;
  
    
    public void SelectLevel(LevelInfo level)
    {
        levelInfo = level;
        levelNameText.text = level.levelname;
        levelNumberText.text = "Nivel " + level.number;
    }


}
