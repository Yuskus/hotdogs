using UnityEngine;

public class Level_41 : MonoBehaviour //������,������� - 2 ������� - ��������� ����� 4
{
    private Game game;
    private LearningPointer lp;
    private readonly int levelNum = 40;
    private readonly string levelKey = "Rec_41";
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
    private void Update() //CHECK
    {
        game.TimerForLevel();
    }
    public void AlmostGo()
    {
        lp.TurnLearnOff();
        game.LearningPointer.SetActive(false);
        game.learn = false;
        game.TabloOn();
        game.StoikaOnly.transform.GetChild(16).GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
        Invoke(nameof(Go), 4f);
    }
    private void Learning()
    {
        game.learn = true;
        game.LearningPointer.SetActive(true);
        lp = game.LearningPointer.GetComponent<LearningPointer>();
        game.StoikaOnly.transform.GetChild(16).GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        lp.Press(game.StoikaOnly.transform.GetChild(18).gameObject);
        lp.WriteText("�������� �������� �� ����� ����������: ���������!");
        Invoke(nameof(AlmostGo), 4f);
    }
    private void Go() => game.TheFirstFew(9, 2.5f, 3.4f, 4, levelKey, levelNum); //CHECK
}
