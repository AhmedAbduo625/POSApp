

namespace POSAppCore
{
    public class CustomItemViewModel : BaseViewModel
    {
        #region PRIVATE MEMEBERS

        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region PUBLIC PROPERTIES



        #endregion

        #region ICONS
        public Icons PlusIcon { get; set; } = Icons.PlusIcon;
        public Icons MinusIcon { get; set; } = Icons.MinusIcon;

        #endregion

        #region COMMANDS


        #endregion

        #region CONSTRUCTOR

        public CustomItemViewModel()
        {

        }

        #endregion

        #region PRIVATE METHODS


        #endregion

        #region PUBLIC METHODS


        #endregion
    }
}
