using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] RectTransform rectTransform;
    [SerializeField] Key KeyPrefab;
    [SerializeField] Key BackSpaceKey;
    [SerializeField] Text outputText;

    [Header(" Settinges ")]
    [Range(0f, 1f)]
    [SerializeField] float WidthPercent;
    [Range(0f, 1f)]
    [SerializeField] float HeightPercent;
    [Range(0f, 0.5f)]
    [SerializeField] float ButtomOffset;

    [Header(" Keyboard Line ")]
    [SerializeField] keyboard[] lines;

    [Header(" Key Setting ")]
    [Range(0f, 1f)]
    [SerializeField] float keyToLineRatio;
    [Range(0f,1f)]
    [SerializeField] float KeyXSpacing;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        CreateKeys();
        yield return null;

        updateRectTransform();

        //rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
        updateRectTransform();
        PlaceKeys();
    }

    void updateRectTransform()
    {
        float width = WidthPercent * Screen.width;
        float height = HeightPercent * Screen.height;


        //configure the size of the keyboard container
        rectTransform.sizeDelta = new Vector2(width, height);

        //Configure the buttom offset
        Vector2 position;

        position.x = Screen.width / 2;
        position .y = ButtomOffset * Screen.height + height / 2;

        rectTransform.position = position;
    }

    private void CreateKeys()
    {
        for (int i=0; i<lines.Length; i++)
        {
            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                char key = lines[i].keys[j];

                if (key == '.')
                {
                    Key keyInstance = Instantiate(BackSpaceKey, rectTransform);

                    keyInstance.GetButton().onClick.AddListener(() =>BackSpacePressedCallback());
                }
                else
                {
                    Key keyInstance = Instantiate(KeyPrefab, rectTransform);
                    keyInstance.SetKey(key);

                    keyInstance.GetButton().onClick.AddListener(() => KeyPressedCallBack(key));
                }


            }
        }
    }

    private void PlaceKeys()
    {
        int lineCount = lines.Length; 
        float lineHeight = rectTransform.rect.height/lineCount;
        float keyWidth = lineHeight * keyToLineRatio;

        float xSpacing = KeyXSpacing * lineHeight;

        int currentKeyIndex = 0; 
        for (int i=0; i<lineCount; i++)
        {
            bool contaisBackSpace = lines[i].keys.Contains(".");

            float halfKeyCount = (float)lines[i].keys.Length/2;
            if (contaisBackSpace)
            {
                halfKeyCount += .5f;
            }

            float startX = rectTransform.position.x - (keyWidth + xSpacing) * halfKeyCount + (keyWidth + xSpacing) / 2;

            float lineY = rectTransform.position.y + rectTransform.rect.height / 2 - lineHeight / 2 - i * lineHeight;


            for (int j = 0; j < lines[i].keys.Length; j++)
            {
                bool isBackSpace = lines[i].keys[j] == '.';

                float keyX = startX + j * (keyWidth + xSpacing);

                if (isBackSpace)
                {
                    keyX += keyWidth - xSpacing;
                }

                Vector2 keyPosition = new Vector2(keyX, lineY);

                RectTransform keyRectTransform = rectTransform.GetChild(currentKeyIndex).GetComponent<RectTransform>();
                keyRectTransform.position = keyPosition;

                float thisKeyWidth = keyWidth;
                if (isBackSpace)
                {
                    thisKeyWidth *= 2; 
                }

                keyRectTransform.sizeDelta = new Vector2(thisKeyWidth, keyWidth);

                currentKeyIndex++;
            }
        }
    }
    private void BackSpacePressedCallback()
    {
        //string newText = "";
        //for (int i = 0; i < outputText.text.Length - 1; i++)
        //{
        //    newText += outputText.text[i];
        //}

        //outputText.text = newText;
        if(outputText.text.Length > 0)
        {
            outputText.text = outputText.text.Substring(0, outputText.text.Length - 1);
        }
        
    }

    private void KeyPressedCallBack(char key) 
    {
        outputText.text = outputText.text + key;
    }


}


[System.Serializable]
public struct keyboard
{
    public string keys;
}
