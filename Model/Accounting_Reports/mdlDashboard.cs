namespace EXIN.Model
{
    public class mdlDashboard
    {
        public static string MdlSalesbyBrand = @"SELECT tbl_transaction.Category_Code, 
                                                                if(tbl_chartofaccounts.NormalBalance = 'Credit', -round(Sum(Amount)/1000,0), round(Sum(Amount)/1000,0))  As Total, Transaction_Date, 
                                                                tbl_transaction.GLSL, tbl_chartofaccounts.ExpandedAccounts AS PnlAccount
                                                                FROM tbl_transaction
                                                                LEFT OUTER JOIN
                                                                (SELECT Category_Code, GLSL,tbl_chartofaccounts.ExpandedAccounts, tbl_expandedpnlaccounts.NormalBalance
                                                                FROM tbl_chartofaccounts left outer join tbl_expandedpnlaccounts
                                                                ON tbl_chartofaccounts.ExpandedAccounts = tbl_expandedpnlaccounts.ExpandedAccounts)tbl_chartofaccounts
                                                                ON tbl_transaction.GLSL = tbl_chartofaccounts.GLSL
                                                                AND tbl_transaction.Category_Code = tbl_chartofaccounts.Category_Code
                                                                WHERE tbl_transaction.Status = 'Active'
                                                                AND tbl_chartofaccounts.ExpandedAccounts = @pnlAccountNumber
                                                                AND Transaction_Date BETWEEN @startDate AND @endDate
                                                                GROUP BY Category_Code;";

        public static string MdlSalesbyStores = @"SELECT tbl_transaction.Category_Code, tbl_units.Unit_Name,  
                                                                if(tbl_chartofaccounts.NormalBalance = 'Credit', -round(Sum(Amount)/1000,0), round(Sum(Amount)/1000,0))  As Total, Transaction_Date, 
                                                                tbl_transaction.GLSL, tbl_chartofaccounts.ExpandedAccounts AS PnlAccount
                                                                FROM tbl_transaction
                                                                LEFT OUTER JOIN
                                                                (SELECT Category_Code, GLSL,tbl_chartofaccounts.ExpandedAccounts, tbl_expandedpnlaccounts.NormalBalance
                                                                FROM tbl_chartofaccounts left outer join tbl_expandedpnlaccounts
                                                                ON tbl_chartofaccounts.ExpandedAccounts = tbl_expandedpnlaccounts.ExpandedAccounts)tbl_chartofaccounts
                                                                ON tbl_transaction.GLSL = tbl_chartofaccounts.GLSL
                                                                AND tbl_transaction.Category_Code = tbl_chartofaccounts.Category_Code
                                                                LEFT OUTER join tbl_units
                                                                ON tbl_transaction.Unit_Code = tbl_units.Unit_Code
                                                                WHERE tbl_transaction.Status = 'Active'
                                                                AND tbl_transaction.Category_Code = @categoryCode
                                                                AND tbl_chartofaccounts.ExpandedAccounts = @pnlAccountNumber
                                                                 AND Transaction_Date BETWEEN @startDate AND @endDate
                                                                GROUP BY tbl_units.Unit_Name
                                                                ORDER BY Total ASC;";

        public static string MdlSalesbyDate = @"SELECT tbl_transaction.Category_Code, Unit_Code,  Transaction_Date,
                                                                if(tbl_chartofaccounts.NormalBalance = 'Credit', -round(Sum(Amount)/1000,0), round(Sum(Amount)/1000,0))  As Total, 
                                                                tbl_transaction.GLSL, tbl_chartofaccounts.ExpandedAccounts AS PnlAccount
                                                                FROM tbl_transaction
                                                                LEFT OUTER JOIN
                                                                (SELECT Category_Code, GLSL,tbl_chartofaccounts.ExpandedAccounts, tbl_expandedpnlaccounts.NormalBalance
                                                                FROM tbl_chartofaccounts left outer join tbl_expandedpnlaccounts
                                                                ON tbl_chartofaccounts.ExpandedAccounts = tbl_expandedpnlaccounts.ExpandedAccounts) tbl_chartofaccounts
                                                                ON tbl_transaction.GLSL = tbl_chartofaccounts.GLSL
                                                                AND tbl_transaction.Category_Code = tbl_chartofaccounts.Category_Code
                                                                WHERE tbl_transaction.Status = 'Active'
                                                                AND tbl_chartofaccounts.ExpandedAccounts = @pnlAccountNumber
                                                                AND tbl_chartofaccounts.Category_Code =  @categoryCode
                                                                AND Unit_Code = @unitCode
                                                                AND Transaction_Date BETWEEN @startDate AND @endDate
                                                                GROUP BY Unit_Code, Transaction_Date
                                                                ORDER BY Transaction_Date DESC
                                                                LIMIT 7;";

    }
}
