using System.Text;
using System.Collections.Generic;

public class CompositeItem : AbstractItem
{
    // ICollection é o tipo mais abstrato que nos permite adicionar e remover
    // itens de uma coleção
    private ICollection<AbstractItem> items;

    // O peso de um item composto é igual ao peso de todos os itens que ele
    // contém
    public override float Weight
    {
        get
        {
            float totalWeight = 0;
            foreach (AbstractItem item in items)
            {
                totalWeight += item.Weight;
            }
            return totalWeight;
        }
    }

    // Construtor de CompositeItem
    public CompositeItem()
    {
        // Na prática a nossa coleção será uma lista
        items = new List<AbstractItem>();
    }

    // Adicionar um item à coleção
    public override void Add(AbstractItem item)
    {
        items.Add(item);
    }

    // Remover um item da coleção
    public override void Remove(AbstractItem item)
    {
        items.Remove(item);
    }

    // Percorrer os itens da coleção
    public override IEnumerator<AbstractItem> GetEnumerator()
    {
        foreach (AbstractItem item in items)
        {
            yield return item;
        }
    }

    // Método ToString() para facilitar debugging
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("(");
        foreach (AbstractItem item in items)
        {
            sb.Append(item + ", ");
        }
        sb.Append(")");
        return sb.ToString();
    }
}
