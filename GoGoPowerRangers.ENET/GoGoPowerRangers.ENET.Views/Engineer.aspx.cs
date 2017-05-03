using GoGoPowerRangers.ENET.Data;
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
    public partial class Engineer : System.Web.UI.Page
    {
        private SiteEngineer _user;

        protected void btnNewIntervention_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateIntervention.aspx", true);
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["currentUser"] = null;
            Response.Redirect("LoginPage.aspx", true);
        }

        protected void newClientButton_Click(object sender, EventArgs e)
        {
            string name = newClientName.Text.ToString();
            string location = newClientLocation.Text.ToString();
            //check inputs

            _user.CreateClient(name, location);

            BindClients();
            newClientName.Text = "";
            newClientLocation.Text = "";
            UpdateClients.Update();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _user = (SiteEngineer)Session["currentUser"];
                if (_user == null)
                    Response.Redirect("LoginPage.aspx");
            }
            catch
            {
                Response.Redirect("LoginPage.aspx");
            }
            
            if (!IsPostBack)
            {
                
                labelFirstName.Text = _user.FirstName;
                labelDistrictName.Text = "<h2>Clients in " + _user.District.Name + "</h2>";
                labelInterventionsHeader.Text = "<h2>Interventions proposed by " + _user.FirstName + " " + _user.LastName + "</h2";

                BindClients();
                var dataSource = _user.GetInterventions();
                interventionGrid.DataSource = dataSource;
                if (dataSource.Count != 0 && interventionGrid.DataSource != null)
                {
                    interventionGrid.DataBind();
                    interventionGrid.UseAccessibleHeader = true;
                    interventionGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                    interventionGrid.DataBind();
            }
		}

        protected void changePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword", true);
        }

        private void BindClients()
        {
            var dataSource = _user.ListClientsInDistrict();
            clientGrid.DataSource = dataSource;
            if (dataSource.Count != 0 && clientGrid.DataSource != null)
            {
                clientGrid.DataBind();
                clientGrid.UseAccessibleHeader = true;
                clientGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
		}

		protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "clientNameClick")
            {
                ClientTableAdapter clientTable = new ClientTableAdapter();
                var dbClient = clientTable.GetClientById(id).FirstOrDefault();
                if (dbClient != null)
                {
                    Session.Add("selectedClient", _user.ConvertDbClientToClient(dbClient));
                    Response.Redirect("ClientDetails.aspx");
                }
                //else
                //    ErrorMessage.Text = "Invalid Client!";
            }
            else if (e.CommandName == "viewInterventionClick")
            {
                InterventionTableAdapter interventionTable = new InterventionTableAdapter();
                var dbIntervention = interventionTable.GetInterventionById(id).FirstOrDefault();
                if (dbIntervention != null)
                {
                    Session.Add("selectedIntervention", _user.ConvertDbInterventionToIntervention(dbIntervention));
                    Response.Redirect("InterventionDetails.aspx");
                }
                //else
                //    ErrorMessage.Text = "Invalid Intervention!";
            }
        }
    }
}
