using System.Collections;
public class FireBlast : BaseSkill
{

    public FireBlast()
   : base(8F, 5F)
    {

    }



    public override string getName()
    {
        return "FireBlast";
    }

    protected override IEnumerator onActivate(CharacterStats target)
    {
        return null;

    }

    protected override void onInactivate(CharacterStats target)
    {

    }
}
