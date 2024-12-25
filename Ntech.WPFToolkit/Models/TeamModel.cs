namespace SampleWpfDataGrid
{
    #region #using Directives

    using System.Collections.ObjectModel;

    #endregion

    public class TeamModel
    {
        #region Properties

        public ObservableCollection<IPlayerAge> PlayerAges { get; set; }

        #endregion
    }
}