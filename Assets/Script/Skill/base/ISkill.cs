public interface ISkill
{
    string getName();
    void activate(CharacterStats target);
    void Inactivate(CharacterStats target);
    void update();

}
