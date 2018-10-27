namespace NsuGo.Definition.Utilities
{
    public class ListGroup
    {
        public string Name
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public ListGroup(string name)
        {
            Name = name;
            Order = 1;
        }

        public ListGroup(string name, int order) : this(name)
        {
            Order = order;
        }
    }
}
