using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] AudioMixerGroup mixerGroup;
    [SerializeField] Image soundButtonImg;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject nextLevelPanel;
    [SerializeField] TextMeshProUGUI levelInfoText;

    private void Start()
    {
        MenuHolder.Prefab = nextLevelPanel;    
    }

    public void OpenMenu()
    {
        nextLevelPanel.SetActive(false);
        menuPanel.SetActive(true);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));      
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(Data.CurrentLevel, LoadSceneMode.Additive);
        nextLevelPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        Data.CurrentLevel++;
        if (Data.CurrentLevel > 3)
            Data.CurrentLevel = 1;
        OpenLevel(Data.CurrentLevel);
        nextLevelPanel.SetActive(false);
    }

    //В идеале лучше всего делать генерацию кнопок в зависимости от количества уровней, однако тут всего 3 уровня и в угоду времени я решил не делать так (хотя умею)
    public void OpenLevel(int Index)
    {
        Data.CurrentLevel = Index;
        nextLevelPanel.SetActive(false);
        menuPanel.SetActive(false);
        levelInfoText.text = string.Format("Уровень: {0}", Index);
        SceneManager.LoadSceneAsync(Index, LoadSceneMode.Additive);
    }

    public void OnOffSounds()
    {
        Data.isMusicOn = !Data.isMusicOn;
        if (Data.isMusicOn)
        {
            mixerGroup.audioMixer.SetFloat("MasterVolume", 0f);
            soundButtonImg.color = Color.green;
        }
        else 
        {
            mixerGroup.audioMixer.SetFloat("MasterVolume", -80f);
            soundButtonImg.color = Color.red;
        }
    }
}
