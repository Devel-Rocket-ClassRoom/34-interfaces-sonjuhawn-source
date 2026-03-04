using System;

// README.md를 읽고 코드를 작성하세요.

Character player = new Character("용사", 20);
Monster slime = new Monster("슬라임", 30, 5);

Console.WriteLine("=== 전투 시작 ===");
ProcessBattle(player, slime);
ProcessBattle(slime, player);
ProcessBattle(player, slime);

Console.WriteLine("=== 고블린 등장 ===");
Monster goblin = new Monster("고블린", 50, 10);
ProcessBattle(player, goblin);
ProcessBattle(goblin, player);
ProcessBattle(player, goblin);
ProcessBattle(player, goblin);

void ProcessBattle(IAttacker attacker, IDefender defender)
{
    attacker.Attack(defender);
}



interface IAttacker
{
    int AttackPower { get; }
    void Attack(IDefender target);
}
interface IDefender
{
    string Name { get; }
    int MaxHp { get; }
    bool IsDead { get; }
    void TakeDamage(int damage);
    int currentHp { get; }
}
class Character : IAttacker, IDefender
{
    public string Name { get; }
    public int AttackPower { get; }

    public int MaxHp { get; } = 100;

    public bool IsDead { get; private set; }

    public int currentHp { get; set; }
    public Character(string name, int attackPower)
    {
        Name = name;
        AttackPower = attackPower;
        currentHp = MaxHp;
    }

    public void Attack(IDefender target)
    {
        target.TakeDamage(AttackPower);
        Console.WriteLine($"용사(이/가) {target.Name}에게 {AttackPower} 대미지! ({target.Name} HP: {target.currentHp}/{target.MaxHp})");
        if(target.currentHp == 0)
        {
            Console.WriteLine($"{target.Name}(이/가) 쓰러졌습니다!");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if(currentHp < 0)
        {
            currentHp = 0;
        }
    }
}
class Monster : IAttacker, IDefender
{
    public int AttackPower { get;  }

    public string Name { get; }

    public int MaxHp { get; }

    public bool IsDead { get; private set; } = false;
    public int currentHp { get; private set; }

    public Monster(string name, int maxhp, int attackpower)
    {
        Name = name;
        MaxHp = maxhp;
        currentHp = maxhp;
        AttackPower = attackpower;
    }

    public void Attack(IDefender target)
    {
        target.TakeDamage(AttackPower);
        Console.WriteLine($"용사(이/가) {target.Name}에게 {AttackPower} 대미지! ({target.Name} HP: {target.currentHp}/{target.MaxHp})");
        if (target.currentHp == 0)
        {
            Console.WriteLine($"{target.Name}(이/가) 쓰러졌습니다!");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            currentHp = 0;
        }
    }
}