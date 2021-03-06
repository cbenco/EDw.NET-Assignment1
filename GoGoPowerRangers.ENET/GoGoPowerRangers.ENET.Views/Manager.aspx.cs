﻿using GoGoPowerRangers.ENET.Data;
using GoGoPowerRangers.ENET.Data.ENETTableAdapters;
using GoGoPowerRangers.ENET.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoGoPowerRangers.ENET.Views
{
    public partial class manager : System.Web.UI.Page
    {
        private static List<Intervention> _interventions;
        private Manager _user;
        public GridView clientGrid, interventionGrid;
        private InterventionTableAdapter interventionTable;
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("LoginPage.aspx", true);
        }
		
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _user = (Manager)Session["currentUser"];
                if (_user == null)
                    Response.Redirect("LoginPage.aspx");
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");
            }
            if (!IsPostBack)
            {
                interventionTable = new InterventionTableAdapter();
                labelFirstName.Text = _user.FirstName;
                labelInterventionsHeader.Text = "<h2>Interventions for " + _user.FirstName + "</h2";

                BindInterventions();
            }
        }
        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx", true);
        }

        

        protected void interventionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ApproveClick")
            {
                int Id = int.Parse(e.CommandArgument.ToString());
                var intervention = _interventions.FirstOrDefault(c => c.Id == Id);

                _user.ChangeInterventionState(intervention, Status.Approved);

                BindInterventions();
                updateApprovedText.Update();
            }
        }

        protected void BindInterventions()
        {
            _interventions = _user.GetPendingInterventions();
            interventionGrid.DataSource = _interventions;
            if (_interventions.Count != 0 && _interventions != null)
            {
                interventionGrid.DataBind();
                interventionGrid.UseAccessibleHeader = true;
                interventionGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
                interventionGrid.DataBind();
		}
    }
}