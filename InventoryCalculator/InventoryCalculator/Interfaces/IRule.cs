using System;

namespace InventoryCalculator.Interfaces
{ 
    /// <summary>
    /// Rule used by rule engine
    /// </summary>
    public interface IRule<T>
        where T : IData
    {
        public string Name { get;}

        public T Apply(T item);
    }
}
