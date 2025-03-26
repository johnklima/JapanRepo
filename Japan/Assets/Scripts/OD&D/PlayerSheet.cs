using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace player
{

    [System.Serializable]
    public class PlayerSheet
    {
        public string Name;
        
        public int STR;
        public int INT;
        public int WIS;
        public int CON;
        public int DEX;
        public int CHR;
        public int MAGR;
        public int HP;
        public int AC;
        public int ENC;
        public int ALGN;
        public int LVL;

        //0.001 - 1.00 by 3, 6 sided dice when applied to the NN
        public float STRf;
        public float INTf;
        public float WISf;
        public float CONf;
        public float DEXf;
        public float CHRf;
        public float MAGRf;
        public float HPf;
        public float ACf;
        public float ENCf;
        public float ALGNf;
        public float LVLf;


        public int ImHit;
        public int HitHim;

        private Transform owner;

        public PlayerSheet(Transform _owner)
        {
            //must first initialize all


            //stats as floats to be sent to the NN
            STRf = 0; 
            INTf = 0; 
            WISf = 0;
            CONf = 0;
            DEXf = 0;
            CHRf = 0;
            MAGRf = 0;
            HPf = 0;
            ACf = 0;
            ENCf = 0;
            ALGNf = 0;
            LVLf = 1.0f/20.0f ; //highest level

            Name = _owner.name;
            owner = _owner;

            //stats as ints for LUTs and ease of use
            STR = 0;
            INT = 0;
            WIS = 0;
            CON = 0;
            DEX = 0;
            CHR = 0;
            MAGR = 0;
            HP = 0;
            AC = 0;
            ENC = 0;
            ALGN = 0;
            LVL = 1;

            ImHit = 0;
            HitHim = 0;

            //goofy, now I can call 'this' to init real values

            STR = randomStat();
            INT = randomStat();
            WIS = randomStat();
            CON = randomStat();
            DEX = randomStat();
            CHR = randomStat();
            MAGR = (INT + WIS + CHR) / 3;

            HP = HPscaleLevel(LVL);
            AC = Random.Range(3, 19);

            float coef  = (float)(AC - STR + 16) /32.0f ;
            ENC = (int)(18.0f * coef);

            ALGN = Random.Range(0, 3);

            //float them 0.001 - 1.00
            //NOTE: All floart stats will change over time due to a variety of factors and will
            //      reflect in the integers by truncation
            STRf = STR/18f;
            INTf = INT/18f;
            WISf = WIS/18f;
            CONf = CON/18f;
            DEXf = DEX/18f;
            CHRf = CHR/18f;
            HPf = HP/8f;
            ENCf = ENC / 18f;
            ALGNf = ALGN / 3f;
            //align is a "leaning" towards Law (0.0 - 0.3), Neutral (0.3 - 0.6), Chaos(0.6 - 1.0)
            //and can change over time, depending on outcomes from encounters

            

        }
        int HPscaleLevel(int level)
        {
            //initial HP dice in OD&D are determined by class, but as we are as yet classless, it needs to be
            //some coefficient of STR and CON - so just invent it.
            //NOTE: diverging from D&D giving mages +0, clerics +1, and fighters +2
            
            int hp = 0;
            float scale = (STR + CON) * 0.01f;
            //18 + 18 = 36 which would be the max possible, so scale < .12 magic, < .24 cleric < .36 fighter
            hp = Random.Range(1, 7);
            
            if (scale < 0.12f)
                hp += 0;
            else if (scale < 0.24f)
                hp += 1;
            else if (scale < 0.36)
                hp += 2;

            return hp *  level; //TODO: this might need rethunk as characters level up

        }

        //OD&D never specified mods by stats, AD&D did a little so I'll use that as a guideline
        //as my NN will depend on it. for ease of understanding using ints, can float them if needed
        public int modBySTR()
        {
            //sword/mace/dagger modifier for all
            if (STR <= 3)
                return -3;
            if (STR <= 5)
                return -2;
            if (STR <= 7)
                return -1;
            if (STR <= 16)
                return 0;
            if (STR <= 18)
                return 1;
            
            return 0;
        }
        public int modByINT()
        {
            //spell modifier (mage spell, damage spell)
            if (INT <= 3)
                return -3;
            if (INT <= 5)
                return -2;
            if (INT <= 7)
                return -1;
            if (INT <= 16)
                return 0;
            if (INT <= 17)
                return 1;
            if (INT <= 18)
                return 2;

            return 0;
        }
        public int modByWIS()
        {
            //spell modifier (cleric spell, heal spell)
            if (WIS <= 3)
                return -3;
            if (WIS <= 4)
                return -2;
            if (WIS <= 7)
                return -1;
            if (WIS <= 14)
                return 0;
            if (WIS <= 15)
                return 1;
            if (WIS <= 16)
                return 2;
            if (WIS <= 17)
                return 3;
            if (WIS <= 18)
                return 4;

            return 0;
        }
        public int modByCON()
        {
            return 0;
        }
        public int modByDEX()
        {
            //misile modifier
            if (DEX <= 3)
                return -3;
            if (DEX <= 4)
                return -2;
            if (DEX <= 7)
                return -1;
            if (DEX <= 15)
                return 0;
            if (DEX <= 16)
                return 1;
            if (DEX <= 17)
                return 2;
            if (DEX <= 18)
                return 2;

            return 0;
        }
        public int modByCHR()
        {
            return 0;
        }

        public int modByENC()
        {
            //encumberance modifier
            if (ENC <= 3)
                return 2;
            if (ENC <= 4)
                return 1;
            if (ENC <= 7)
                return -1;
            if (ENC <= 11)
                return -2;
            if (ENC <= 15)
                return -4;
            if (ENC <= 16)
                return -7;
            if (ENC <= 17)
                return -9;
            if (ENC <= 18)
                return -10;

            return 0;
        }






        int randomStat()
        {
            //6 sided dice, as floats
            int s = 0;
                
            s+= Random.Range(1, 7);
            s+= Random.Range(1, 7);
            s+= Random.Range(1, 7);
            
            return s;
        }


        public void save()
        {

            string path = Application.dataPath + "/Data/" + Name + ".json";
            Debug.Log("player sheet saved " + path);

            string saveData = JsonUtility.ToJson(this);
            File.WriteAllText(path, saveData);


        }

        public bool load()
        {
            //load persitant data
            string path = Application.dataPath + "/Data/" + Name + ".json";
            
            if (File.Exists(path))   //just do it
            {
                string loadPlayerData = File.ReadAllText(path);
                JsonUtility.FromJsonOverwrite(loadPlayerData, this);
                Debug.Log("loaded " + path);

                return true;
            }
            else
            {
                Debug.Log("Just to let you know, there are no save files yet to load." + Name);
                return false;
            }                

        }
    }
}
