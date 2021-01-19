using System.Collections.Generic;
using System.Linq;
using TestAssignment.BL.Abstraction;

namespace TestAssignment.BL.Impl
{
    public class ElementMerger : IElementMerger
    {
        private static ElementMerger _element;
        
        private ElementMerger(){}

        public static ElementMerger Get() => _element ??= new ElementMerger();

        public IEnumerable<IElement> MergeElements(IEnumerable<IElement> elements, IElement newElement)
        {
            var sortList = elements.OrderBy(n => n.Number).ToList();
            var list = sortList.Take(newElement.Number - 1);
            
            list = list.Append(newElement);

            for (var i = newElement.Number - 1; i < sortList.Count; i++)
            {
                if(sortList[i].Number == i + 1) sortList[i].Number += 1;
                list = list.Append(sortList[i]);
            }
            return list;
        }
    }
}