namespace SampleWpfDataGrid
{
    #region #using Directives

    using System.Collections.ObjectModel;

    #endregion

    public partial class SampleDataGridUserControl
    {
        #region Construction

        public SampleDataGridUserControl()
        {
            InitializeComponent();

            SetupDesignTimeModel();
        }

        #endregion

        #region Setting Up Model for Testing Purposes

        private void SetupDesignTimeModel()
        {
            var playerAges = new ObservableCollection<IPlayerAge>();

            var alphaTeam = new PlayerAge(null, "1", true, true, "Alpha Team", 0, 0, string.Empty, 0);
            playerAges.Add(alphaTeam);
            playerAges.Add(new PlayerAge(alphaTeam, "11", false, true, "John Smith", 32, 3, "Senior", 0.11));
            playerAges.Add(new PlayerAge(alphaTeam, "12", false, true, "Jesse Furher", 17, 3, "Junior", 0.11));
            playerAges.Add(new PlayerAge(alphaTeam, "13", false, true, "Alfred Morgan", 18, 3, "Junior", 0.11));
            playerAges.Add(new PlayerAge(alphaTeam, "14", false, true, "John Mufin", 9, 3, "Mini", 0.11));
            playerAges.Add(new PlayerAge(alphaTeam, "15", false, true, "Andrea Pascal", 78, 3, "Veteran", 0.11));
            var betaTeam = new PlayerAge(null, "2", true, true, "Beta Team", 0, 0, string.Empty, 0);
            playerAges.Add(betaTeam);
            playerAges.Add(new PlayerAge(betaTeam, "21", false, true, "Mark Smith", 32, 3, "Senior", 0.11));
            playerAges.Add(new PlayerAge(betaTeam, "22", false, true, "Furin Furher", 17, 3, "Junior", 0.11));
            playerAges.Add(new PlayerAge(betaTeam, "23", false, true, "Johana Morgan", 18, 3, "Junior", 0.11));
            playerAges.Add(new PlayerAge(betaTeam, "24", false, true, "Albert Mufin", 9, 3, "Mini", 0.11));
            playerAges.Add(new PlayerAge(betaTeam, "25", false, true, "Snoopy Pascal", 78, 3, "Veteran", 0.11));

            DataContext = new TeamModel {PlayerAges = playerAges};
        }

        #endregion
    }
}