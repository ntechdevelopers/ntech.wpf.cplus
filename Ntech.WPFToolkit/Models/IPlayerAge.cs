namespace SampleWpfDataGrid
{
    public interface IPlayerAge
    {
        IPlayerAge Parent { get; set; }

        string Id { get; set; }
        bool IsExpanded { get; set; }
        bool IsEnabled { get; set; }
        string Name { get; set; }
        double Age { get; set; }
        double Deviation { get; set; }
        string Category { get; set; }
        double DeviationPercentage { get; set; }

        bool IsSubItem { get; }
    }
}