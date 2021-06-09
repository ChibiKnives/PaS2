namespace PaS2.Core.Abstraction.Interfaces
{
    public interface ILoadable
    {
        float Priority { get; }

        bool LoadOnDedServer { get; }

        void Load();

        void Unload();
    }
}
