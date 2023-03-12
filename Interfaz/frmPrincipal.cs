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
    }
}
