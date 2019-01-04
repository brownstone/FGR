using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using OnefallGames;

public class UpgradeController : MonoBehaviour {

    [Header("Upgrade Config")]
    [SerializeField] private int SSUpgradePrice = 5;
    [SerializeField] private int BPUpgradePrice = 5;

    [Header("Upgrade References")]
    [SerializeField] private Text coinTxt;
    [SerializeField] private Text SS_LevelTxt;
    [SerializeField] private Text BP_LevelTxt;
    [SerializeField] private Text SSUpgradePriceTxt;
    [SerializeField] private Text BPUpgradePriceTxt;
    [SerializeField] private Button SS_UpgradeBtn;
    [SerializeField] private Button BP_UpgradeBtn;

    private void Start()
    {
        Application.targetFrameRate = 60;

        int ssLevel = DataController.Get_SS_Level();
        for(int i = 1; i < ssLevel; i++)
        {
            SSUpgradePrice += SSUpgradePrice;
        }

        int bpLevel = DataController.Get_BP_Level();
        for(int i = 1; i < bpLevel; i++)
        {
            BPUpgradePrice += BPUpgradePrice;
        }
    }


    // Update is called once per frame
    void Update () {

        coinTxt.text = CoinManager.Instance.Coins.ToString();
        SSUpgradePriceTxt.text = SSUpgradePrice.ToString();
        BPUpgradePriceTxt.text = BPUpgradePrice.ToString();
        SS_LevelTxt.text = "LEVEL: " + DataController.Get_SS_Level().ToString();
        BP_LevelTxt.text = "LEVEL: " + DataController.Get_BP_Level().ToString();

        if (CoinManager.Instance.Coins > SSUpgradePrice)
            SS_UpgradeBtn.interactable = true;
        else
            SS_UpgradeBtn.interactable = false;
        if (CoinManager.Instance.Coins > BPUpgradePrice)
            BP_UpgradeBtn.interactable = true;
        else
            BP_UpgradeBtn.interactable = false;

	}

    public void Upgrade_SS()
    {
        if (DataController.Get_SS_Level() < DataController.Max_SS_Level)
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.unlock);
            DataController.Increase_SS_Level(1);
            CoinManager.Instance.RemoveCoins(SSUpgradePrice);
            SSUpgradePrice += SSUpgradePrice;
        }
    }

    public void Upgrade_BP()
    {
        if (DataController.Get_BP_Level() < DataController.Max_BP_Level)
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.unlock);
            DataController.Increase_BP_Level(1);
            CoinManager.Instance.RemoveCoins(BPUpgradePrice);
            BPUpgradePrice += BPUpgradePrice;
        }
    }

    public void BackBtn()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.button);
        SceneManager.LoadScene("Gameplay");
    }
}
