using System;

// README.md를 읽고 코드를 작성하세요.
Console.WriteLine("'''");
Car car = new Car();
car.Go();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
IRepository repository = new Repository();
repository.Get();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
Person person = new Person();
person.Work();
person.Reset();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
Car1 car1 = new Car1(new GoodBattery());
car1.Run();
Car1 car2 = new Car1(new NormalBattery());
car2.Run();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
Dog dog1 = new Dog();
dog1.Eat();
dog1.Bark();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
Bird bird = new Bird();
bird.Breath();
bird.Fly();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
Pet pet = new Pet();
((IDog1)pet).Eat();
((ICat1)pet).Eat();

IDog1 dog2 = new Pet();
dog2.Eat();
ICat1 cat = new Pet();
cat.Eat();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
EXample example = new EXample();
IExample ex = example;
ex.DoWork();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
TextEditor text = new TextEditor();
text.Undo();
text.Redo();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
Car2 car3 = new Car2();
car3.Run();
car3.Left();
car3.Back();

Console.WriteLine("'''\n");

Console.WriteLine("'''");
Player player = new Player();
Enemy enemy = new Enemy();
Building building = new Building();
Attack(player, 20);
Attack(enemy, 30);
Attack(building, 100);
void Attack(IDamageable target, int damage)
{
    target.TakeDamage(damage);
}

Console.WriteLine("'''\n");

Console.WriteLine("'''");
Hero hero = new Hero();
Turret turret = new Turret();
hero.Move();
hero.Attack();
turret.Attack();

Console.WriteLine("'''\n");


interface ICar
{
    public void Go();
}
class Car : ICar
{
    public void Go()
    {
        Console.WriteLine("자동차가 달립니다.");
    }
}

interface IRepository
{
    public void Get();
}
class Repository : IRepository
{
    public void Get()
    {
        Console.WriteLine("데이터를 가져옵니다.");
    }
}

interface IPerson
{
    public void Work();
    public void Reset();
}
class Person : IPerson
{
    public void Reset()
    {
        Console.WriteLine("일을 합니다.");
    }

    public void Work()
    {
        Console.WriteLine("휴식을 취합니다.");
    }
}

interface IBattery
{
    string GetName();
}
class GoodBattery : IBattery
{
    public string GetName()
    {
        return "고급 배터리";
    }
}
class NormalBattery : IBattery
{
    public string GetName()
    {
        return "일반 배터리";
    }
}
class Car1
{
    private IBattery battery;

    public Car1(IBattery battery)
    {
        this.battery = battery;
    }
    public void Run()
    {
        Console.WriteLine($"{battery}를 장착한 자동차가 달립니다.");
    }
}

interface IAnimal
{
    void Eat();
}
interface IDog
{
    void Bark();
}
class Dog : IAnimal, IDog
{
    public void Bark()
    {
        Console.WriteLine("짖습니다");
    }

    public void Eat()
    {
        Console.WriteLine("먹습니다");
    }
}

interface IFlyable
{
    void Fly();
}
class Animal 
{
    public void Breath()
    {
        Console.WriteLine("숨을 쉽니다.");
    }
}
class Bird : Animal, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("날아갑니다.");
    }
}

interface IDog1
{
    void Eat();
}
interface ICat1
{
    void Eat();
}
class Pet : IDog1, ICat1
{
    void IDog1.Eat()
    {
        Console.WriteLine("개처럼 먹습니다.");
    }
    void ICat1.Eat()
    {
        Console.WriteLine("고양이처럼 먹습니다.");
    }
}

interface IExample
{
    void DoWork();
}
class EXample : IExample
{
    public void DoWork()
    {
        Console.WriteLine("작업 수행");
    }
}

interface IUndoable
{
    void Undo();
}
interface IRedoable : IUndoable
{
    void Redo();
}
class TextEditor : IRedoable
{
    public void Redo()
    {
        Console.WriteLine("다시 실행");
    }

    public void Undo()
    {
        Console.WriteLine("실행 취소");
    }
}

interface IStandard
{
    void Run();
}
abstract class Vehicle
{
    public abstract void Back();
    public void Left()
    {
        Console.WriteLine("좌회전");
    }
}
class Car2 : Vehicle, IStandard
{
    public override void Back()
    {
        Console.WriteLine("후진");
    }

    public void Run()
    {
        Console.WriteLine("전진");
    }
}

interface IDamageable
{
    public int Health { get; }
    void TakeDamage(int damage);
}
class Player : IDamageable
{
    public int Health { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"플레이어가 {damage} 대미지를 받음. 남은 체력: {Health}");
    }
}
class Enemy : IDamageable
{
    public int Health { get; private set; } = 50;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"적이 {damage} 대미지를 받음. 남은 체력: {Health}");
    }
}
class Building : IDamageable
{
    public int Health { get; private set; } = 500;

    public void TakeDamage(int damage)
    {
        Health -= damage; ;
        Console.WriteLine($"건물이 {damage} 대미지를 받음. 남은 내구도: {Health}");
    }
}

interface IMovable
{
    void Move();
}
interface IAttackable
{
    void Attack();
}
class Hero : IMovable, IAttackable
{
    public void Attack()
    {
        Console.WriteLine("영웅이 공격합니다.");
    }

    public void Move()
    {
        Console.WriteLine("영웅이 이동합니다.");
    }
}
class Turret : IAttackable
{
    public void Attack()
    {
        Console.WriteLine("포탑이 발사합니다.");
    }
}