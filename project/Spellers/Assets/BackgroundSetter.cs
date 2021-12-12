using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;
using Levels;


    public class BackgroundSetter : MonoBehaviour
    {
         public List<Sprite> backgrounds;
         public SpriteRenderer bg_image;

         public void Start()
         {
            SetBackground();
        }

        private void SetBackground()
        {
            int bg_id; 
            if(GameManager.instance.GetSettings() is LevelGameSettings levelGameSettings)
            {
                int lvlId = levelGameSettings.LevelIndex;
                if (lvlId == 3 || lvlId == 6 || lvlId == 7)
                {
                    bg_id = 1;
                }                    
                else if(lvlId > 12)
                {
                    bg_id = 2;
                }
                else
                {
                    bg_id = 0;
                }
            }
            else
            {
                bg_id = Random.Range(0, backgrounds.Count);
            }
            bg_image.sprite = backgrounds[bg_id];
                    
      }

    } 

