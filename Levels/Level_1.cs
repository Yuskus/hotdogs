using UnityEngine;

public class Level_1 : MonoBehaviour //������,�������,����� - 3 ������� - ��������� ����� 0
{
    private Game game;
    private LearningPointer lp;
    private readonly int levelNum = 0;
    private readonly string levelKey = "Rec_01";
    private void Awake()
    {
        game = Camera.main.GetComponent<Game>();
        game.AwakeAnyLevel();
    }
    private void Start()
    {
        game.StartAnyLevel();
        if (RecData.ContinueGame == RecData.AvailableLevels) { Learning(); }
        else
        {
            game.TabloOn();
            Invoke(nameof(Go), 5f);
        }
    }
    private void Update()
    {
        game.TimerForLevel();
    }
    public void AlmostGo()
    {
        lp.TurnLearnOff();
        game.LearningPointer.SetActive(false);
        game.TabloOn();
        game.StoikaOnly.transform.GetChild(16).GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        Invoke(nameof(Go), 4f);
    }
    public void Go() => game.TheFirstFew(3, 3.4f, 4.1f,2,levelKey, levelNum);
    private void Learning()
    {
        game.learn = true;
        game.LearningPointer.SetActive(true);
        lp = game.LearningPointer.GetComponent<LearningPointer>();
        game.StoikaOnly.transform.GetChild(5).GetComponent<BoxCollider2D>().enabled = false;
        game.StoikaOnly.transform.GetChild(16).GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        game.SauceK.GetComponent<BoxCollider2D>().enabled = false;
        lp.Press(game.StoikaOnly.transform.GetChild(6).gameObject);
        lp.WriteText("�������� �� ���� ������� ��� �������.");
    }
}
