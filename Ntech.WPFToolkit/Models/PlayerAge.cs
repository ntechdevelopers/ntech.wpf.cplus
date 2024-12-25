namespace SampleWpfDataGrid
{
    public class PlayerAge : IPlayerAge
    {
        #region Construction

        public PlayerAge(IPlayerAge parent, string id, bool isExpanded, bool isEnabled, string name, double age,
                         double deviation, string category, double percentage)
        {
            Parent = parent;
            Id = id;
            IsExpanded = isExpanded;
            IsEnabled = isEnabled;
            Name = name;
            Age = age;
            Deviation = deviation;
            Category = category;
            DeviationPercentage = percentage;
        }

        #endregion

        #region Implementation of IPersonAge

        public IPlayerAge Parent { get; set; }

        public string Id { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsEnabled { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public double Deviation { get; set; }
        public string Category { get; set; }
        public double DeviationPercentage { get; set; }

        public bool IsSubItem
        {
            get { return Parent != null; }
        }

        #endregion
    }
}