using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpellSystem;
using System.Linq;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    const string chars = "abcdefghijklmnopqrstuvwxyz";

    public GameObject header, body;
    public GameObject prefab;

    void Start()
    {
        generateBody(5, 4, 0.01f);
    }


    private void generateBody(int rows, int columns, float spacing)
    {
        float rowsize = Mathf.Max((1 - (rows - 1) * spacing)  / rows, 0);
        float colsize = Mathf.Max((1 - (columns - 1) * spacing) / columns, 0);
        float size = Mathf.Min(rowsize, colsize);
        float xdelta = rowsize > colsize ? ((size * colsize + spacing * (colsize - 1)) * 0.5f) : 0;
        float ydelta = colsize > rowsize ? ((size * rowsize + spacing * (rowsize - 1)) * 0.5f) : 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var o = Instantiate(prefab, transform);
                var rt = o.GetComponent<RectTransform>();
                rt.anchorMin = new Vector2(j * (size + spacing), i * (size + spacing)) + new Vector2(xdelta, ydelta);
                rt.anchorMax = rt.anchorMin + new Vector2(size, size);

                var button = o.GetComponent<Button>();
                SetEvent(button, i, j);
            }
        }
    }

    private void SetEvent(Button b, int i, int j)
    {
        b.onClick.AddListener(() => Debuger());
    }

    private string GenerateRandomWord(int length, string charSet)
    {
        var random = new System.Random();
        var randomString = new string(Enumerable.Repeat(charSet, length).Select(
            s => s[random.Next(s.Length)]).ToArray());
       return randomString;
    }

    void Debuger()
    {
        string s = GenerateRandomWord(8, chars);
        // w = ajxjuiop
        Debug.Log(s);

        string c = RemoveIntersect(s, chars);
        // c = bcdefghklmnqrstuvwyz
        string k = GenerateRandomWord(25 - 8, c);
        string v = s + k;

        Debug.Log(v);
        Debug.Log(Shuffle(v));


    }

    // Mezcla las letras de una palabra.
    public static string Shuffle(string str)
    {
        char[] array = str.ToCharArray();
        var rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return new string(array);
    }

    // Devuelve un array de caracteres con las letras de una palabra que no están en otro.
    public static string RemoveIntersect(string str, string chars)
    {
        string s = "";
        foreach (var character in chars)
        {
            if (!str.Contains(character))
                s += character;
        }
        return s;


    }
}
