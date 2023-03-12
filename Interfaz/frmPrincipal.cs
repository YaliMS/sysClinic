using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using DevExpress.DXperience.Demos;
using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace Interfaz
{
    public partial class frmPrincipal : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        async Task LoadModuleAsync(ModuleInfo module)
        {
            await Task.Factory.StartNew(() =>
            {
                    if (!fluentDesignFormContainer1.Controls.ContainsKey(module.Name))
                    { 
                        TutorialControlBase control = module.TModule as TutorialControlBase;

                        if(control != null)
                        {
                            control.Dock = DockStyle.Fill;
                            control.CreateWaitDialog();
                            fluentDesignFormContainer1.Invoke(new MethodInvoker(delegate()
                            {
                                fluentDesignFormContainer1.Controls.Add(control);
                                control.BringToFront();
                            }));
                        }
                    }
                    else
                    {
                        var control = fluentDesignFormContainer1.Controls.Find(module.Name, true);
                    if (control.Length == 1)
                        fluentDesignFormContainer1.Invoke
                        (
                            new MethodInvoker
                            (
                                delegate ()
                                {
                                    control[0].BringToFront();
                                }

                            ));
                    }
            });
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
          
        }

        private async void NE_Click(object sender, EventArgs e)
        {
            //muestra el userControl al hacer click en el submenu Nuevo
            this.fluentDesignFormContainer1.Controls.Add(new ucNEmpleado() { Dock = DockStyle.Fill });

            //Muestra en que menu se encuentra "migas de pan"
            this.itemNav.Caption = $"{accordionControlElement1.Text}/{NE.Text}";

            //if (ModulesInfo.GetItem("ucNEmplead") == null)
            //    ModulesInfo.Add(new ModulesInfo("ucNEmplead"));
            ////*//, "fluentDesignFormContainer1.ucNEmplead"));
            //await LoadModuleAsync(ModulesInfo.GetItem("ucNEmplead")); ;

        }
    }
}
