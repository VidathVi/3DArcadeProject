using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject interactButton;
    public TextMeshProUGUI gametext;
    public string gameName;
    public string sceneName;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            interactButton.SetActive(true);
            gametext.text = gameName;
            if (Input.GetKeyDown(KeyCode.E) && interactButton.activeSelf == true)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactButton.SetActive(true);
            gametext.text = gameName;
            if (Input.GetKeyDown(KeyCode.E) && interactButton.activeSelf == true)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactButton.SetActive(false);
            gametext.text = " ";
        }
    }
}
