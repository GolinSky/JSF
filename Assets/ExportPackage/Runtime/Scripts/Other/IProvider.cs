namespace ExportPackage.Runtime.Scripts.Other
{
    public interface IProvider<out T>
    {
         T Value { get; }
    }
}