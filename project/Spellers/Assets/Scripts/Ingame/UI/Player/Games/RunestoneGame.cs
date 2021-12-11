using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Utils;

namespace Ingame.UI
{
    public class RunestoneGame : GameBoard
    {
        public static readonly string CHARSET = "ABCDEFGHIJKLMNOPJRSTUVWXYZ";
        [SerializeField] private GameObject runestone;
        [SerializeField] private TextMeshProUGUI spellword_txt; 

        private string spellword;
        private int currentCharIdx;
        private List<Runestone> runes;
        private Vector2Int dimension;

        private void Awake() 
        {
            runes = new List<Runestone>();
        }

        public override void Generate()
        {
            currentCharIdx = 0;
            spellword = GenerateRandomWord();
            spellword_txt.text = spellword;
            dimension = SetBoardDimensions(4);
            char[] keys = GenerateAllKeys(dimension.x * dimension.y);
            for (var i = 0; i < dimension.y; i++)
            {
                for (var j = 0; j < dimension.x; j++)
                {
                    Vector2 pos = new Vector2(j, i);
                    Runestone runestone = GenerateRunestone(pos, dimension);
                    runestone.SetUp(keys[j + i * dimension.x], CheckKey);
                    runes.Add(runestone);
                }
            }
        }

        private string GenerateRandomWord()
        {
            return Extensions.GenerateRandomWord(4, CHARSET);
        }

        private char[] GenerateAllKeys(int length)
        {
            return Extensions.GenerateRandomKeys(length, spellword, 0, CHARSET);
        }

        private int SetSpellwordLength(int difficulty)
        {
            return difficulty;
        }

        private Vector2Int SetBoardDimensions(int difficulty)
        {
            return new Vector2Int(3,5);
        }

        private Runestone GenerateRunestone(Vector2 pos, Vector2 size)
        {
            var obj = Instantiate(runestone, rectTransform);
            var rt = obj.GetComponent<RectTransform>();
            var s = 1f / Mathf.Max(size.x, size.y);
            var runesize = new Vector2(s, s);
            var xdelta = Mathf.Max(0f, 1f - (size.x / size.y)) * 0.5f;
            var ydelta = Mathf.Max(0f, 1f - (size.y / size.x)) * 0.5f;
            var delta = new Vector2(xdelta, ydelta);
            rt.anchorMin = delta + pos * runesize;
            rt.anchorMax = rt.anchorMin + runesize;
            return obj.GetComponent<Runestone>();
        }

        private bool CheckKey(char runekey)
        {
            Debug.Log("Check if " + runekey + " == " + spellword[currentCharIdx]);
            if(runekey == spellword[currentCharIdx])
            {
                currentCharIdx++;
                if(currentCharIdx >= spellword.Length)
                {
                    Success();
                    Clear();
                }
                return true;                
            }
            else
            {
                Fail();
                Clear();
                return false;                
            }
        }

        private void Clear()
        {
            foreach(var rune in runes)
            {
                Destroy(rune.gameObject);
            }
            runes.Clear();
        }

    }

}
