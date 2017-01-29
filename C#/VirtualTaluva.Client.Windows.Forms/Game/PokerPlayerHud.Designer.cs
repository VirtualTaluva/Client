﻿namespace VirtualTaluva.Client.Windows.Forms.Game
{
    partial class PlayerHud
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.picBlind = new VirtualTaluva.Client.Windows.Forms.Game.ButtonPictureBox();
            this.picCard4 = new VirtualTaluva.Client.Windows.Forms.Game.CardPictureBox();
            this.picCard3 = new VirtualTaluva.Client.Windows.Forms.Game.CardPictureBox();
            this.picDealer = new VirtualTaluva.Client.Windows.Forms.Game.ButtonPictureBox();
            this.picCard2 = new VirtualTaluva.Client.Windows.Forms.Game.CardPictureBox();
            this.picCard1 = new VirtualTaluva.Client.Windows.Forms.Game.CardPictureBox();
            this.picCard5 = new VirtualTaluva.Client.Windows.Forms.Game.CardPictureBox();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBlind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(30, 58);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 28);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "$557";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(178)))), ((int)(((byte)(194)))));
            this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(121, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Player Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAction
            // 
            this.lblAction.BackColor = System.Drawing.Color.White;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(0, 20);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(121, 15);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "CHECK";
            this.lblAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.White;
            this.pnlCenter.Controls.Add(this.picCard5);
            this.pnlCenter.Controls.Add(this.picBlind);
            this.pnlCenter.Controls.Add(this.lblStatus);
            this.pnlCenter.Controls.Add(this.picCard4);
            this.pnlCenter.Controls.Add(this.picCard3);
            this.pnlCenter.Controls.Add(this.picDealer);
            this.pnlCenter.Controls.Add(this.picCard2);
            this.pnlCenter.Controls.Add(this.picCard1);
            this.pnlCenter.Location = new System.Drawing.Point(-2, 35);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(123, 88);
            this.pnlCenter.TabIndex = 3;
            // 
            // picBlind
            // 
            this.picBlind.BackColor = System.Drawing.Color.Transparent;
            this.picBlind.Location = new System.Drawing.Point(93, 56);
            this.picBlind.Name = "picBlind";
            this.picBlind.Size = new System.Drawing.Size(30, 30);
            this.picBlind.TabIndex = 3;
            this.picBlind.TabStop = false;
            // 
            // picCard4
            // 
            this.picCard4.BackColor = System.Drawing.Color.Transparent;
            this.picCard4.Location = new System.Drawing.Point(62, 1);
            this.picCard4.Name = "picCard4";
            this.picCard4.Size = new System.Drawing.Size(40, 56);
            this.picCard4.TabIndex = 5;
            this.picCard4.TabStop = false;
            // 
            // picCard3
            // 
            this.picCard3.BackColor = System.Drawing.Color.Transparent;
            this.picCard3.Location = new System.Drawing.Point(42, 1);
            this.picCard3.Name = "picCard3";
            this.picCard3.Size = new System.Drawing.Size(40, 56);
            this.picCard3.TabIndex = 4;
            this.picCard3.TabStop = false;
            // 
            // picDealer
            // 
            this.picDealer.BackColor = System.Drawing.Color.Transparent;
            this.picDealer.Location = new System.Drawing.Point(0, 56);
            this.picDealer.Name = "picDealer";
            this.picDealer.Size = new System.Drawing.Size(30, 30);
            this.picDealer.TabIndex = 2;
            this.picDealer.TabStop = false;
            // 
            // picCard2
            // 
            this.picCard2.BackColor = System.Drawing.Color.Transparent;
            this.picCard2.Location = new System.Drawing.Point(22, 1);
            this.picCard2.Name = "picCard2";
            this.picCard2.Size = new System.Drawing.Size(40, 56);
            this.picCard2.TabIndex = 1;
            this.picCard2.TabStop = false;
            // 
            // picCard1
            // 
            this.picCard1.BackColor = System.Drawing.Color.Transparent;
            this.picCard1.Location = new System.Drawing.Point(2, 1);
            this.picCard1.Name = "picCard1";
            this.picCard1.Size = new System.Drawing.Size(40, 56);
            this.picCard1.TabIndex = 0;
            this.picCard1.TabStop = false;
            // 
            // picCard5
            // 
            this.picCard5.BackColor = System.Drawing.Color.Transparent;
            this.picCard5.Location = new System.Drawing.Point(82, 1);
            this.picCard5.Name = "picCard5";
            this.picCard5.Size = new System.Drawing.Size(40, 56);
            this.picCard5.TabIndex = 6;
            this.picCard5.TabStop = false;
            // 
            // PlayerHud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(98)))), ((int)(((byte)(114)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlCenter);
            this.Name = "PlayerHud";
            this.Size = new System.Drawing.Size(121, 121);
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBlind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCard5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Panel pnlCenter;
        private CardPictureBox picCard2;
        private CardPictureBox picCard1;
        private ButtonPictureBox picBlind;
        private ButtonPictureBox picDealer;
        private CardPictureBox picCard4;
        private CardPictureBox picCard3;
        private CardPictureBox picCard5;
    }
}
