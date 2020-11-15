using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCVisual : MonoBehaviour {
    private Sprite female;
    private Sprite male;

    private Sprite[] outFits;
    private Sprite[] haircuts;

    private Sprite sleeve;
    private Sprite noSleeve;
    private Sprite arm;

    [SerializeField]
    private SpriteRenderer gender;
    
    [SerializeField]
    private SpriteRenderer outfit;
    
    [SerializeField]
    private SpriteRenderer haircut;
    
    [SerializeField]
    private SpriteRenderer sleeves;

    [SerializeField] 
    private SpriteRenderer arms;


    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        female = Resources.Load<Sprite>("NPC/female");
        male = Resources.Load<Sprite>("NPC/male");

        outFits = new Sprite[4];
        outFits[0] = Resources.Load<Sprite>("NPC/outfit1");
        outFits[1] = Resources.Load<Sprite>("NPC/outfit2");
        outFits[2] = Resources.Load<Sprite>("NPC/outfit3");
        outFits[3] = Resources.Load<Sprite>("NPC/outfit4");

        haircuts = new Sprite[5];
        haircuts[0] = Resources.Load<Sprite>("NPC/haircut1");
        haircuts[1] = Resources.Load<Sprite>("NPC/haircut2");
        haircuts[2] = Resources.Load<Sprite>("NPC/haircut3");
        haircuts[3] = Resources.Load<Sprite>("NPC/haircut4");
        haircuts[4] = Resources.Load<Sprite>("NPC/haircut5");

        sleeve = Resources.Load<Sprite>("NPC/sleeve");
        noSleeve = Resources.Load<Sprite>("NPC/empty");
        arm = Resources.Load<Sprite>("NPC/arm");

        createNPC();
        print(gender.color);
    }

    private void Update() {
        var velocity = _rb.velocity;
        var flipX = velocity.x < 0;
        gender.flipX = flipX;
        outfit.flipX = flipX;
        sleeves.flipX = flipX;
        arms.flipX = flipX;
        haircut.flipX = flipX;
    }

    void createNPC() {
        arms.sprite = arm;
        Color[] skinTones = new Color[] {new Color	((float)45 / 255, (float)34/ 255, (float)30/ 255), 
            new Color	((float)26/255, (float)17/255, (float)6/255), new Color	((float)66/255, (float)43/255, (float)15/255), 
            new Color	((float)135/255, (float)103/255, (float)90/255), new Color	((float)165/255, (float)120/255, (float)105/255), 
            new Color	((float)195/255, (float)149/255, (float)130/255), new Color	((float)225/255, (float)172/255, (float)150/255), 
            new Color	((float)255/255, (float)195/255, (float)170/255), new Color	((float)225/255, (float)218/255, (float)190/255)
        };
        
        Color[] hairColors = new Color[] {Color.black	, 
            new Color	((float)75/255, (float)57/255, (float)50/255), new Color	((float)105/255, (float)80/255, (float)70/255), 
            new Color	((float)106/255, (float)69/255, (float)24/255), new Color	((float)146/255, (float)95/255, (float)33/255), 
            new Color	((float)186/255, (float)121/255, (float)42/255), new Color	((float)212/255, (float)145/255, (float)65/255), 
            new Color	((float)221/255, (float)168/255, (float)105/255), new Color	((float)255/255, (float)249/255, (float)24/255),
            new Color	((float)80/255, (float)10/255, (float)9/255)
        };
        
        if (Random.value < 0.5) {
            gender.sprite = female;
        }
        else {
            gender.sprite = male;
        }

        if (Random.value < 0.7) {
            sleeves.sprite = sleeve;
        }

        if (gender.sprite == female) {
            if (Random.value < 0.5) {
                outfit.sprite = outFits[0];
            }
            else {
                outfit.sprite = outFits[1];
            }
        }
        else {
            if (Random.value < 0.5) {
                outfit.sprite = outFits[2];
            }
            else {
                outfit.sprite = outFits[3];
            }
        }
        Color outfitColor = new Color(Random.value, Random.value, Random.value);
        outfit.color = outfitColor;
        sleeves.color = outfitColor;

        float rand = Random.value;

        if (rand < 0.25) {
            haircut.sprite = haircuts[1];
        }
        else if (rand < 0.5) {
            haircut.sprite = haircuts[2];
        }
        else if (rand < 0.75) {
            haircut.sprite = haircuts[3];
        }
        else {
            if (gender.sprite == female) {
                haircut.sprite = haircuts[0];
            }
            else {
                haircut.sprite = haircuts[4];
            }
        }
        gender.color = skinTones[Random.Range(0, 9)];
        arms.color = gender.color;

        haircut.color = hairColors[Random.Range(0, 10)];
    }

    public Color getHairColor() {
        return haircut.color;
    }
}
