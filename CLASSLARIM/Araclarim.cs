using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Label = System.Windows.Forms.Label;


namespace KuryePera
{
     class Araclarim
    {
    }
    class lblstandart : Label
    {
        public lblstandart()
        {
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.Text = "orneklabel";
            this.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "lblstandart";

        }       
    }

    class btnstandart : Button
    {
        public btnstandart()
        {
            this.ForeColor= System.Drawing.Color.Green;
            this.Text = "ornekbuton";
            this.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "btnstandart";
        }
    }
}
