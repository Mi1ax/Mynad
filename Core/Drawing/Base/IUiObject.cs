namespace Core.Drawing.Base
{
    public interface IUiObject: IDrawable, IUpdatable
    {
        public abstract IUiObject Copy();
    }
}