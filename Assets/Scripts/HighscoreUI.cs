using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreUI : MonoBehaviour {

    public GameObject highscoreTextPrefab;
    public GameObject textContainer;
    public float height = 0;

    string level = "RedLevel";

	// Use this for initialization
	void Start () {
        //LoadLevelTexts();
    }

    void Update()
    {
        transform.Translate(0, Time.deltaTime * 5, 0);

        //Debug.Log(transform.localPosition.y + ":" + height);

        if(transform.localPosition.y > height)
        {
            //Debug.Log("Restarting");
            transform.localPosition = new Vector3(transform.localPosition.x, 80f, transform.localPosition.z);
            //GetComponent<RectTransform>().position = new Vector3(transform.position.x, -910f, transform.position.z);
            //GetComponent<RectTransform>().anchoredPosition = new Vector3(GetComponent<RectTransform>().anchoredPosition.x, -910f, GetComponent<RectTransform>().anchoredPosition.z);
        }
    }

    public void ChangeLevel(string level)
    {
        switch (level)
        {
            case "RedLevel":
                this.level = level;
                LoadLevelTexts();
                break;
            case "Green Level":
                this.level = level;
                LoadLevelTexts();
                break;
            case "BlueLevel":
                this.level = level;
                LoadLevelTexts();
                break;
            default:
                Debug.Log("HighscoreUI ERROR: Invalid level");
                break;
        }
    }

    public void LoadLevelTexts()
    {

        Text[] OldTexts = GetComponentsInChildren<Text>();
        if(OldTexts != null)
        {
            foreach(Text text in OldTexts)
            {
                Destroy(text.gameObject);
            }
        }

        string[] texts = System.IO.File.ReadAllLines(level+".txt");
        height = (texts.Length * 90) + 1050;

        //GetComponent<RectTransform>().sizeDelta = new Vector2(900, height);

        string levelName = "";
        switch (level)
        {
            case "RedLevel":
                levelName = "Red Level";
                break;
            case "Green Level":
                levelName = "Green Level";
                break;
            case "BlueLevel":
                levelName = "Blue Level";
                break;
            default:
                Debug.Log("HighscoreUI ERROR: Invalid level");
                break;
        }

        GameObject a = Instantiate(highscoreTextPrefab, textContainer.transform);
        a.GetComponent<Text>().text = string.Format("<b>{0}</b>", levelName);
        GameObject aa = Instantiate(highscoreTextPrefab, textContainer.transform);
        aa.GetComponent<Text>().text = string.Format("");
        GameObject b = Instantiate(highscoreTextPrefab, textContainer.transform);
        b.GetComponent<Text>().text = string.Format("{0,-25}", "Name");
        GameObject c = Instantiate(highscoreTextPrefab, textContainer.transform);
        c.GetComponent<Text>().text = string.Format("{0,-25}", "Time");

        foreach (string s in texts)
        {

            string stringA = "";
            string stringB = "";

            bool done = false;
            for (int i = 0; !done; i++)
            {
                if(s[i] == ',')
                {
                    for (int y = i + 1; y < s.Length; y++)
                    {
                        stringB += s[y];
                    }
                    done = true;
                }
                else
                {
                    stringA += s[i];
                }
            }

            GameObject namego = Instantiate(highscoreTextPrefab, textContainer.transform);
            GameObject scorego = Instantiate(highscoreTextPrefab, textContainer.transform);
            namego.GetComponent<Text>().text = string.Format("{0,-25}", stringA);
            scorego.GetComponent<Text>().text = string.Format("{0,-25}", stringB);
        }

        transform.position = new Vector3(transform.position.x, 80, transform.position.z);
    }
}
