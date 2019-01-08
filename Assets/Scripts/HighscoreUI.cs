using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.IO;

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

public class HighscoreUI : MonoBehaviour
{

    public GameObject highscoreTextPrefab;
    public GameObject textContainer;
    public float height = 0;

    public string level = "RedLevel";

    string hashA = "t¤#e%#¤54.3%#¤45.5h65&35654¤6g%¤6.sr45&.456345.45t6¤%345&45h6.¤%6g3345&6445.&w%6y45&45.dfg33&.4455%¤%54h5rea*";
    string hashB = "*t¤#e%#¤543%34#.¤5h65&354566¤6.g%¤6sr4345.5&45645t6¤%.&45h.6¤%6g3&6.445345&w%6y45&45.3&4455%¤%54h5rea";

    // Use this for initialization
    void Start()
    {
        //LoadLevelTexts();
        //TestSaveAsBinary();
        //TestLoadBinary();
    }

    void TestSaveAsBinary()
    {
        string[] texts = File.ReadAllLines("RedLevel.txt");
        using (FileStream fs = new FileStream("Test.dat", (FileMode.CreateNew)))
        {
            using (BinaryWriter w = new BinaryWriter(fs))
            {
                List<string> data = new List<string>();
                foreach (string s in texts)
                {
                    if (s.Length == 0)
                    {
                        continue;
                    }

                    string stringA = hashA;
                    string stringB = hashA;

                    //bool done = false;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i] == ',')
                        {
                            for (int y = i + 1; y < s.Length; y++)
                            {
                                stringB += s[y];
                            }
                            //done = true;
                            break;
                        }
                        else
                        {
                            stringA += s[i];
                        }
                    }

                    string dataString = "\n" + stringA + "," + stringB;
                    data.Add(dataString);
                }

                foreach (string s in data)
                {
                    w.Write(s);
                }
            }
        }

        File.SetAttributes("Test.dat", File.GetAttributes("Test.dat") | FileAttributes.Hidden);
    }

    void TestLoadBinary()
    {
        try
        {   // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader("Test.dat"))
            {
                // Read the stream to a string, and write the string to the console.
                string line = sr.ReadToEnd();

                Debug.Log(line);

                string[] lines = line.Split('\n');

                foreach (string s in lines)
                {
                    if (s.Length == 0)
                    {
                        continue;
                    }

                    string stringA = "";
                    string stringB = "";

                    bool done = false;
                    for (int i = 0; i < s.Length && !done; i++)
                    {
                        if (s[i] == '*')
                        {
                            for (int j = i + 1; j < s.Length; j++)
                            {
                                if (s[j] == ',')
                                {
                                    for (int k = j + 1; s[k] != '*'; k++)
                                    {
                                        stringB += s[k];
                                    }
                                    done = true;
                                }
                                else
                                {
                                    stringA += s[j];
                                }
                            }
                        }
                    }

                    string dataString = "\n" + stringA + "," + stringB;
                    Debug.Log(stringA + "," + stringB);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }
    }

    void Update()
    {
        transform.Translate(0, Time.deltaTime * 5, 0);

        //Debug.Log(transform.localPosition.y + ":" + height);

        if (transform.localPosition.y > height)
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
        if (OldTexts != null)
        {
            foreach (Text text in OldTexts)
            {
                Destroy(text.gameObject);
            }
        }

        string[] texts;
        try
        {
            texts = System.IO.File.ReadAllLines(level + ".txt");
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message + ": unable to open " + level + ".txt");
            return;
        }

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
            if (s.Length == 0)
            {
                continue;
            }

            string stringA = "";
            string stringB = "";

            //bool done = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',')
                {
                    for (int y = i + 1; y < s.Length; y++)
                    {
                        stringB += s[y];
                    }
                    //done = true;
                    break;
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
        foreach (Highscore h in sortedHighscores)
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
