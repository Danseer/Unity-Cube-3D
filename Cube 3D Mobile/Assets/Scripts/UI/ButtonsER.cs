using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsER : MonoBehaviour
{

    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private Button reloadButton;



    void Awake()
    {
        exitButton.onClick.AddListener(OnExitGame);
        reloadButton.onClick.AddListener(OnReloadGame);
    }
      
    public void OnReloadGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnExitGame()
    {
        Application.Quit();
    }


}
