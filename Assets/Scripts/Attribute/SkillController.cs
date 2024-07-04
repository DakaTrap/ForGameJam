using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [System.Serializable]
    public class Skill
    {
        public string Name;
        public int MaxLevel;
        public int Level { get; private set; }

        public Skill(string name, int maxLevel)
        {
            Name = name;
            MaxLevel = maxLevel;
            Level = 0;
        }

        public void LevelUp()
        {
            if (Level < MaxLevel)
            {
                Level++;
            }
        }
    }

    public Text[] skillLevelTexts; // 文本显示当前技能等级
    public Button[] upgradeButtons; // 升级按钮，每个按钮对应一个技能

    private Skill[] skills;
    public int totalSkillPointsUsed;
    public int Skillpoint_sum;//天赋点使用计数

    public GameObject[] Lock;//技能锁

    public Text jinengText;
    

    void Start()
    {
        // 初始化技能数组
        skills = new Skill[]
        {
            new Skill("攻击", 3),        
            new Skill("防御", 3),       
            new Skill("血量提升", 3),    
            new Skill("暴击", 3),        
            new Skill("闪避", 3)         
        };

        totalSkillPointsUsed = 0;
        

        // 给每个按钮添加点击事件
        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            int index = i; // 保存当前循环的索引
            upgradeButtons[i].onClick.AddListener(() => UpgradeSkill(index));
        }

        UpdateSkillUI();
    }

    void UpgradeSkill(int index)
    {
        if (totalSkillPointsUsed>0)
        {
            Skill skill = skills[index];
            if (skill.Level >= skill.MaxLevel)
            {
                Debug.LogWarning(skill.Name + "技能已达到最大等级！");
                return;
            }

            // 模拟消耗技能点升级
            skill.LevelUp();
            totalSkillPointsUsed --;
            Skillpoint_sum++;

            // 更新UI显示
            UpdateSkillUI();
            Debug.Log(skill.Name + "技能升级到等级 " + skill.Level);

        }
        if(Skillpoint_sum>=3)
        {
            Lock[0].SetActive(false);
            Lock[1].SetActive(false);
        }
        if (Skillpoint_sum >= 5)
        {
            Lock[2].SetActive(false);
            Lock[3].SetActive(false);
        }


    }

    void UpdateSkillUI()
    {
        // 更新每个技能的UI显示
        jinengText.text = "天赋点:" + totalSkillPointsUsed.ToString(); 
        for (int i = 0; i < skills.Length; i++)
        {
            skillLevelTexts[i].text =  " 等级：" + skills[i].Level;
        }
    }

    public void geiwohenhendetianjiajineng1idan()//狠狠的添加技能点
    {
        totalSkillPointsUsed++;
        UpdateSkillUI() ;
    }
}
