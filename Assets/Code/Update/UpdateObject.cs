namespace Code.Update
{
    public abstract class UpdateObject: IUpdate
    {
        public UpdateObject(Updater updater)
        {
            updater.AddUpdate(this);
        }
        public abstract void Update();

    }
}
