using EXIN.Fixed_Assets_Management_System;
using EXIN.Inventory_System;
using EXIN.Payroll_System;
using EXIN.SalesCollection_System;
using EXIN.Voucher_System;
using System.Windows.Forms;

namespace EXIN.Controller
{
    public class classControl_Docking
    {
        public void ClearUserControls(Control Container)
        {
            foreach (Control c in Container.Controls)
            {
                Container.Controls.Remove(c);
            }
        }

        public virtual void DockControl_PayrollSystem(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            frmPayroll_ParentContainer.Instance.panelContainer2.Controls.Add(userControl);
        }

        public virtual void DockControl_SalesCollection(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            frmSalesCollection_ParentContainer.Instance.panelContainer2.Controls.Add(userControl);
        }

        public virtual void DockControl_InventorySystem(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            frmInventory_ParentContainer.Instance.panelContainer2.Controls.Add(userControl);
        }

        public virtual void DockControl_FixedAssets(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            frmFixedAssets_ParentContainer.Instance.panelContainer2.Controls.Add(userControl);
        }

    }
}
