public interface ISkill
{
    string getName();
    /// <summary>
    /// 쿨타임이 끝나면 스킬을 발동한다.
    /// </summary>
    /// <param name="target"></param>
    void activate(CharacterStats target);

    void Inactivate(CharacterStats target);

    void update();


}
