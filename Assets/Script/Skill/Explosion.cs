using System.Collections;
public class Explosion : BaseSkill
{
   public Explosion()
   : base(8F, 5F)
    {

    }




    public override string getName()
    {
        return "Explosion";
    }

    protected override IEnumerator onActivate(CharacterStats target)
    {
        yield return null;
    }

    protected override void onInactivate(CharacterStats target)
    {

    }
}
