using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatstockv1
{
    public partial class contactComponent : Component
    {
        public contactComponent()
        {
            InitializeComponent();
        }

        public contactComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
