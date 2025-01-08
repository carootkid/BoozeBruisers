using UnityEngine;

public class CoinFlip : MonoBehaviour
{
    [Header("Variables")]
    public Animator coinAnim;
    public bool playerOneOnHeads;
    private int coinHead;
    public bool playerOneWon = false;
    [Header("Objects")]
    public GameObject headBut;
    public GameObject tailBut;
    public GameObject playerOneWins;
    public GameObject playerTwoWins;
    public GameObject infoText;
    [Header("Audio")]
    public AudioSource src;
    public AudioClip clp;
    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0, 50);

        if(randomNum > 25) coinHead = 1;
        if(randomNum < 25) coinHead = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void coinFlipAudio(){
        src.PlayOneShot(clp);
    }

    void Heads(){
        playerOneOnHeads = true;
        flip();
    }

    void Tails(){
        playerOneOnHeads = false;
        flip();
    }
    void flip(){
        tailBut.SetActive(false);
        headBut.SetActive(false);
        infoText.SetActive(false);
        if(coinHead == 0){
            coinAnim.SetTrigger("Heads");
        } else {
            coinAnim.SetTrigger("Tails");
        }
    }

    void revealWinner(){
        if(playerOneOnHeads == true && coinHead == 0){
            playerOneWins.SetActive(true);
            playerOneWon = true;
        } else if(playerOneOnHeads == false && coinHead == 1){
            playerOneWins.SetActive(true);
            playerOneWon = true;
        } else {
            playerTwoWins.SetActive(true);
            playerOneWon = false;
        }
    }
}
