using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZonkManager : MonoBehaviour
{
    [SerializeField] private GameObject skinnedMeshObject1;
    [SerializeField] private GameObject skinnedMeshObject2;

    public bool canClick;

    private SkinnedMeshRenderer skinnedMeshRenderer1;
    private SkinnedMeshRenderer skinnedMeshRenderer2;

    public float PlayerOneZonkLevel = 0f;
    public float PlayerTwoZonkLevel = 0f;

    
    public int playerOneRarityAddition;
    public int playerTwoRarityAddition;
    public float ZonkAddition;

    [Header("Beer stuff")]
    private int HeightIndex1;
    private int WaveIndex1;
    private int HeightIndex2;
    private int WaveIndex2;
    private float currentHeight1 = 0f;
    private float currentHeight2 = 0f;


    public TMP_Text zonkText;

    public float heightSmoothSpeed = 5f;

    private const float MaxHeight = 100f;
    private const float ZonkLevelToHeightFactor = 0.69f;

    void Start()
    {
        playerOneRarityAddition = (int)(PlayerOneZonkLevel / 5f); // addition for making cards appear more often
        playerTwoRarityAddition = (int)(PlayerTwoZonkLevel / 5f); // addition for making cards appear more often
        
        ZonkAddition = 0f; // Addition for making drinks more potent
        canClick = true; // if you can click objects (not including drinks) or not

        skinnedMeshRenderer1 = skinnedMeshObject1.GetComponent<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer1 != null && skinnedMeshRenderer1.sharedMesh != null)
        {
            HeightIndex1 = skinnedMeshRenderer1.sharedMesh.GetBlendShapeIndex("Height");
            WaveIndex1 = skinnedMeshRenderer1.sharedMesh.GetBlendShapeIndex("Wave");
        }

        skinnedMeshRenderer2 = skinnedMeshObject2.GetComponent<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer2 != null && skinnedMeshRenderer2.sharedMesh != null)
        {
            HeightIndex2 = skinnedMeshRenderer2.sharedMesh.GetBlendShapeIndex("Height");
            WaveIndex2 = skinnedMeshRenderer2.sharedMesh.GetBlendShapeIndex("Wave");
        }
    }

    void Update()
    {
        if (skinnedMeshRenderer1 != null)
        {
            if (HeightIndex1 >= 0)
            {
                float targetHeight1 = Mathf.Clamp(PlayerOneZonkLevel * ZonkLevelToHeightFactor, 0, MaxHeight);
                currentHeight1 = Mathf.Lerp(currentHeight1, targetHeight1, Time.deltaTime * heightSmoothSpeed);
                skinnedMeshRenderer1.SetBlendShapeWeight(HeightIndex1, currentHeight1);
            }

            if (WaveIndex1 >= 0)
            {
                float waveValue1 = Mathf.PingPong(Time.time * 7, 8);
                skinnedMeshRenderer1.SetBlendShapeWeight(WaveIndex1, waveValue1);
            }
        }

        if (skinnedMeshRenderer2 != null)
        {
            if (HeightIndex2 >= 0)
            {
                float targetHeight2 = Mathf.Clamp(PlayerTwoZonkLevel * ZonkLevelToHeightFactor, 0, MaxHeight);
                currentHeight2 = Mathf.Lerp(currentHeight2, targetHeight2, Time.deltaTime * heightSmoothSpeed);
                skinnedMeshRenderer2.SetBlendShapeWeight(HeightIndex2, currentHeight2);
            }

            if (WaveIndex2 >= 0)
            {
                float waveValue2 = Mathf.PingPong(Time.time * 7, 8);
                skinnedMeshRenderer2.SetBlendShapeWeight(WaveIndex2, waveValue2);
            }
        }

        if (zonkText != null)
        {
            zonkText.text = $"Player 1 Zonk: {PlayerOneZonkLevel}\nPlayer 2 Zonk: {PlayerTwoZonkLevel}";
        }
    }
}
