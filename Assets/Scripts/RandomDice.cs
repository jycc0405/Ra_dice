using UnityEngine;
using UnityEngine.UI;

public class RandomDice : MonoBehaviour
{
    public Text resultText;
    public Image diceImage;

    // 'dices' 폴더 내의 이미지 파일을 저장할 배열
    public Sprite[] diceSprites;

    private void Start()
    {
        // 'dices' 폴더 내의 이미지 파일들을 로드하여 diceSprites 배열에 저장
        diceSprites = Resources.LoadAll<Sprite>("dices");
    }

    public void OnButtonClick()
    {
        // 랜덤으로 이미지 선택
        int randomIndex = Random.Range(0, diceSprites.Length);
        Sprite selectedDice = diceSprites[randomIndex];

        // 이미지 표시
        diceImage.sprite = selectedDice;
        resultText.text = "뽑은 주사위: " + selectedDice.name;
    }
}
