namespace EXIN.Model.Accounting_Reports
{
    public class mdlComboBoxes : MySqlConnect
    {

        public static string mdlBusUnitNames = @"SELECT Unit_Code, Unit_Name, User_ID FROM (SELECT tbl_credentials_units.Unit_Code,
                                                                tbl_units.Unit_Name, tbl_credentials_units.User_ID  
                                                                FROM tbl_credentials_units LEFT OUTER JOIN tbl_units ON tbl_credentials_units.Unit_Code = tbl_units.Unit_Code) sub
                                                                WHERE User_ID =  @userId
                                                                ORDER BY Unit_Name ASC;";

        public static string mdlPNLAccounts = "SELECT ExpandedAccounts, ExpandedAccountDesc FROM tbl_expandedpnlaccounts;";

        public static string mdlBrandName = "SELECT Category_Code, upper(Category_Name) FROM tbl_Category ORDER BY Category_Name ASC;";

        public static string mdlUnitCode = "SELECT `Unit_Code` FROM `tbl_units` WHERE `Unit_Name` = @Unit_Name";

        public static string mdlBrandCode = "SELECT Category_Code FROM tbl_category WHERE Category_Name = @Brand_Name;";

        public static string mdlPNLCode = "SELECT ExpandedAccounts FROM tbl_expandedpnlaccounts WHERE ExpandedAccountDesc  = @PNLCode_Name";

    }

}
