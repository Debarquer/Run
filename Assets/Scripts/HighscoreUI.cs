using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Highscore
{
    string name;
    float score;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public float Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public Highscore(string name, float score)
    {
        this.name = name;
        this.score = score;
    }
}

public class HighscoreUI : MonoBehaviour {

    public GameObject highscoreTextPrefab;
    public GameObject textContainer;
    public float height = 0;

    public string level = "RedLevel";


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

        List<Highscore> unsortedHighscores = new List<Highscore>();

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

            float score;
            float.TryParse(stringB, out score);
            unsortedHighscores.Add(new Highscore(stringA, score));
        }

        Debug.Log(unsortedHighscores.Count);

        Highscore[] sortedHighscores = SortHighscore(unsortedHighscores);
        foreach(Highscore h in sortedHighscores)
        {
            GameObject namego = Instantiate(highscoreTextPrefab, textContainer.transform);
            GameObject scorego = Instantiate(highscoreTextPrefab, textContainer.transform);
            namego.GetComponent<Text>().text = string.Format("{0,-25}", h.Name);
            scorego.GetComponent<Text>().text = string.Format("{0,-25}", h.Score.ToString());
        }

        transform.position = new Vector3(transform.position.x, 80, transform.position.z);
    }

    public Highscore[] SortHighscore(List<Highscore> unsorted)
    {
        return unsorted.OrderBy(o => o.Score).ToArray();
    }
}
