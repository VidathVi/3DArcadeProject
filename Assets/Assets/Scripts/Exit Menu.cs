using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    public GameObject menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.SetActive(true);
        }
    }

    public void DisableUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
