using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Languager : MonoBehaviour
{
    private string json;
    public static Lang lng=new Lang();

    [SerializeField]
    private Button orks;

    [SerializeField]
    private Button brits;

    [SerializeField]
    private Text start;

    void Awake()
    {
        orks.onClick.AddListener(OrksButton);//
       brits.onClick.AddListener(BritButton);

        if (!PlayerPrefs.HasKey("Languages"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian)
            {
                PlayerPrefs.SetString("Languages", "ru_RU");
            }
            else
            {
                PlayerPrefs.SetString("Languages", "en_US");
            }
        }

        LangLoad();

        start.text = lng.buttons[0];
      
    }

    void OrksButton()
    {
        PlayerPrefs.SetString("Languages", "ru_RU");
        LangLoad();
        
      
            SceneManager.LoadScene("Scenes/" + SceneManager.GetActiveScene().name);
        
    }

    void BritButton()
    {
        PlayerPrefs.SetString("Languages", "en_US");
        LangLoad();
        SceneManager.LoadScene("Scenes/" + SceneManager.GetActiveScene().name);
    }

    void LangLoad()
    {

#if UNITY_ANDROID && !UNITY_EDITOR
        string path = Path.Combine(Application.streamingAssetsPath, "Languages/" + PlayerPrefs.GetString("Languages") + ".json");
        WWW reader = new WWW(path);
        while (!reader.isDone) { }
        json = reader.text;
        lng = JsonUtility.FromJson<Lang>(json);
#endif

#if UNITY_EDITOR
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Languages") + ".json");
        lng = JsonUtility.FromJson<Lang>(json);
#endif

    }

}


public class Lang
{
    public string[] buttons = new string[5];
       
}
