using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulator_App.Controller;

namespace Simulator_App.View
{
    class SimulationOptionsView
    {
        public Label XSizeLabel { get; set; }
        public Label YSizeLabel { get; set; }
        public Label XStartLabel { get; set; }
        public Label YStartLabel { get; set; }
        public Label TresholdLabel { get; set; }
        public Label ReplicationsLabel { get; set; }

        public TextBox XSizeInput { get; set; }
        public TextBox YSizeInput { get; set; }
        public TextBox XStartInput { get; set; }
        public TextBox YStartInput { get; set; }
        public TextBox TresholdInput { get; set; }
        public TextBox ReplicationsInput { get; set; }
        public SimulationOptionsView(Label[] labels, TextBox[] textBoxes)
        {
            XSizeLabel = labels[0];
            YSizeLabel = labels[1];
            XStartLabel = labels[2];
            YStartLabel = labels[3];
            TresholdLabel = labels[4];
            ReplicationsLabel = labels[5];

            XSizeInput = textBoxes[0];
            YSizeInput = textBoxes[1];
            XStartInput = textBoxes[2];
            YStartInput = textBoxes[3];
            TresholdInput = textBoxes[4];
            ReplicationsInput = textBoxes[5];
        }

        public OptionsInput GetOptionsInput()
        {
            var settings = new OptionsInput();
            settings.xSize = this.XSizeInput.Text;
            settings.ySize = this.YSizeInput.Text;
            settings.xStart = this.XStartInput.Text;
            settings.yStart = this.YStartInput.Text;
            settings.numberOfReplications = this.ReplicationsInput.Text;
            settings.tresHold = this.TresholdInput.Text;
            settings.errorOccured = false;
            return settings;
        }

        public void SetOptionsInputText(OptionsInput settings)
        {
            this.XSizeInput.Text = settings.xSize;
            this.YSizeInput.Text = settings.ySize;
            this.XStartInput.Text = settings.xStart;
            this.YStartInput.Text = settings.yStart;
            this.ReplicationsInput.Text = settings.numberOfReplications;
            this.TresholdInput.Text = settings.tresHold;
        }

        public void SetOptionsLablesText(OptionsInput settings)
        {
            XSizeLabel.Text = $"X size (actual {settings.xSize}):";
            YSizeLabel.Text = $"Y size (actual {settings.ySize}):";
            XStartLabel.Text = $"X start position (actual {settings.xStart}):";
            YStartLabel.Text = $"Y start position (actual {settings.yStart}):";
            TresholdLabel.Text = $"Size of K (actual {settings.tresHold}):";
            ReplicationsLabel.Text = $"Replications (actual {settings.numberOfReplications}):";
        }


    }
}
